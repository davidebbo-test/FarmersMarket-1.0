using System;

namespace FarmersMarket.Web.Controls
{
    using Helpers;

    public partial class OperatingHours : System.Web.UI.UserControl
    {
        #region Methods

        public OperatingHours()
        {
            //_MarketDay = DateTime.Now.ThisComing(DayOfWeek.Saturday);
            _marketDay = DateTime.Now.ThisComing(DayOfWeek.Saturday);
        }

        protected string MarketStartTime
        {
            get
            {
                // market starts at 9 AM in Winter, else 8 AM
                return (IsWinterMarket() ? "9" : "8");
            }
        }

        private bool IsWinterMarket()
        {
            return (((_marketDay.Month == 12) || (_marketDay.Month < 4)));
        }

        #endregion Methods

        private DateTime _marketDay;
    }
}