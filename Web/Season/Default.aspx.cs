namespace FarmersMarket.Web
{
    using System;
    using System.Collections.Generic;

    using Helpers;

    public partial class Season : System.Web.UI.Page
    {
        #region Properties

        protected DateTime MarketDay
        {
            get
            {
                // determine the month of the next market day
                //int daysTilSaturday = DayOfWeek.Saturday - DateTime.Today.DayOfWeek;
                //return DateTime.Today.AddDays(daysTilSaturday);

                return DateTime.Now.ThisComing(DayOfWeek.Saturday);
            }
        }

        #endregion Properties

        #region Methods

        protected string MakeHeader()
        {
            var cells = new List<String>(13) {"<th>&nbsp;</th>"};

            for (int month = 1; month <= 12; month++)
            {
                string monthAbbr = new DateTime(DateTime.Today.Year, month, 1).ToString("MMM");

                cells.Add(MarketDay.Month == month
                              ? String.Format("<th class=\"current\">{0}</th>", monthAbbr)
                              : String.Format("<th>{0}</th>", monthAbbr));
            }

            return String.Join(String.Empty, cells.ToArray());
        }

        protected string MakeRow(Produce produce)
        {
            var cells = new List<String>(13);

            if (produce.InSeasonForMonth(MarketDay.Month))
            {
                cells.Add(String.Format("<td class=\"{1}\">{0}</td>",
                    produce.Name, "inseason"));
            }
            else
            {
                cells.Add(String.Format("<td>{0}</td>", produce.Name));
            }

            for (int month = 1; month <= 12; month++)
            {
                string className = (MarketDay.Month == month) ? "current " : String.Empty;

                if (produce.InSeasonForMonth(month))
                {
                    cells.Add(String.Format("<td class=\"{0} available\" title=\"{1}\">&nbsp;</td>", className,
                        new DateTime(DateTime.Today.Year, month, 1).ToString("MMMM")));
                }
                else
                {
                    cells.Add(String.Format("<td class=\"{0}\">&nbsp;</td>", className));
                }
            }

            return String.Join(String.Empty, cells.ToArray());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InSeason.Text = String.Join(", ", Produce.InSeasonOn(MarketDay).ToArray());
                SeasonalAvailability.DataSource = Produce.Seasons;
                DataBind();
            }
        }

        #endregion Methods
    }
}