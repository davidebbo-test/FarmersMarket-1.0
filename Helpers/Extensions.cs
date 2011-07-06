namespace FarmersMarket.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web.UI;

    public static class Extensions
    {
        #region Methods

        public static IEnumerable<Control> GetAllControls(this Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;

                foreach (var descendant in control.GetAllControls())
                {
                    yield return descendant;
                }
            }
        }

        public static DateTime ThisComing(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            // determine the date of the next instance of the specified weekday
            int daysUntil = (int)dayOfWeek - (int)dateTime.DayOfWeek;
            return dateTime.AddDays(daysUntil);
        }

        /// <summary>
        /// Converts the specified DateTime to its relative date.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <returns>A string value based on the relative date
        /// of the datetime as compared to the current date.</returns>
        public static string ToRelativeDate(this DateTime dateTime)
        {
            // 1.
            // Get time span elapsed since the date.
            var s = DateTime.Now.Subtract(dateTime);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                    dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                    Math.Ceiling((double)dayDiff / 7));
            }

            if (dateTime.Year == DateTime.Today.Year)
            {
                return dateTime.ToString("MMMM d");
            }

            return dateTime.ToString("MMMM d, yyyy");
        }

        public static string ToHtml(this string text)
        {
            if (String.IsNullOrEmpty(text)) return String.Empty;

            var regex = new Regex(@"([\w+\.])+(\.(com|org|net))(\/\w*)*");

            return regex.Replace(text.Replace("http://", String.Empty), 
                "<a href=\"http://$0\">$0</a>");            
        }

        #endregion Methods
    }
}