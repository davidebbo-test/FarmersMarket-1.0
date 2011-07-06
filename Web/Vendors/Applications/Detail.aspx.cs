using System;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using FarmersMarket.Helpers;

namespace FarmersMarket.Web.Vendors.Applications
{
    public partial class Detail : System.Web.UI.Page
    {
        public Detail()
        {
            Init += OnPageInit;
            Load += OnPageLoad;
        }

        protected void OnPageLoad(object sender, EventArgs e)
        {
            var applicationXmlFile = Server.MapPath(String.Format("{0}.xml", Request["file"]));

            if (File.Exists(applicationXmlFile))
            {
                var xmlSerializer = new XmlSerializer(typeof(VendorApplication));

                using (var textReader = new StreamReader(applicationXmlFile))
                {
                    VendorApp = xmlSerializer.Deserialize(textReader) as VendorApplication;
                }

                PopulateVendorCalendar();
            }
        }

        protected void OnPageInit(object sender, EventArgs e)
        {
        }

        protected VendorApplication VendorApp;

        private void PopulateVendorCalendar()
        {
            var marketDay = new DateTime(2011, 4, 1);
            var daysTilSaturday = DayOfWeek.Saturday - marketDay.DayOfWeek;
            marketDay = marketDay.AddDays(daysTilSaturday);
            var marketEnds = marketDay.AddYears(1);

            // Market is closed on 11/26
            var marketClosed = new[] { new DateTime(2011, 11, 26) };

            while (marketDay.CompareTo(marketEnds) < 0)
            {
                var row = new TableRow { ID = String.Format("month{0}", marketDay.Month.ToString("D2")) };
                var cells = new[] { new TableCell(), new TableCell(), new TableCell(), new TableCell(), new TableCell(), new TableCell() };

                cells[0].Controls.Add(new Literal { Text = marketDay.ToString("MMMM") });

                int currentMonth = marketDay.Month;

                for (var week = 1; week <= 5; week++)
                {
                    var cssClass = "declined";
                    
                    if (VendorApp.MarketDates.Contains(marketDay))
                        cssClass = "accepted";

                    cells[week].CssClass = cssClass;
                    cells[week].Text = marketDay.Day.ToString();

                    marketDay = marketDay.AddDays(7);

                    if (marketDay.Month != currentMonth)
                        break;
                }

                row.Cells.AddRange(cells);
                marketCalendar.Rows.Add(row);
            }
        }
    }
}