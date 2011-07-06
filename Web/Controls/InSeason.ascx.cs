namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Text;

    using FarmersMarket.Helpers;

    public partial class InSeason : System.Web.UI.UserControl
    {
        #region Methods

        protected string GetProduceInSeason()
        {
            String.Join(", ", Produce.InSeasonOn(DateTime.Today).ToArray());

            int thisMonth = DateTime.Today.Month;
            int prevMonth = (thisMonth > 1) ? (thisMonth - 1) : 12;
            int nextMonth = (thisMonth < 12) ? (thisMonth + 1) : 1;

            const String spanFormat = "{2}<span class=\"{1}\">{0}</span>";
            var sb = new StringBuilder();

            foreach (var item in Produce.Seasons)
            {
                if (item.InSeasonForMonth(thisMonth))
                {
                    if (!item.InSeasonForMonth(prevMonth))
                    {
                        sb.AppendFormat(spanFormat, item.Name, "new", (sb.Length > 0) ? ", " : String.Empty);
                    }
                    else if (!item.InSeasonForMonth(nextMonth))
                    {
                        sb.AppendFormat(spanFormat, item.Name, "ending", (sb.Length > 0) ? ", " : String.Empty);
                    }
                    else
                    {
                        sb.AppendFormat("{1}{0}", item.Name, (sb.Length > 0) ? ", " : String.Empty);
                    }

                }
            }

            return sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}