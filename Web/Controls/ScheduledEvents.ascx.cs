namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using Google.GData.Calendar;
    using System.Net;
    using Google.GData.Client;

    public partial class ScheduledEvents : System.Web.UI.UserControl
    {
        #region Properties

        public Uri Url { get; set; }

        protected String GetCalendarEvents()
        {
            var calendarService = new CalendarService("WesternWakeFarmersMarket");

            calendarService.setUserCredentials(
                ConfigurationManager.AppSettings["FROMEMAIL"], 
                ConfigurationManager.AppSettings["FROMPWD"]);

            var query = new EventQuery
            {
                Uri = new Uri("http://www.google.com/calendar/feeds/westernwakefarmersmarket.org_m0pmqcck35r6n8ag45vifsc4oo%40group.calendar.google.com/public/full")
            };

            var stringBuilder = new StringBuilder("<dl id=\"eventCalendar\">");

            try
            {
                var calendarFeed = calendarService.Query(query);

                var eventDates = (from EventEntry e in calendarFeed.Entries
                                  where (e.Times.Count > 0)
                                  where (e.Times[0].StartTime.CompareTo(DateTime.Today) > 0)
                                  where (!String.IsNullOrWhiteSpace(e.Title.Text))
                                  orderby e.Times[0].StartTime
                                  select e.Times[0].StartTime.Date).Distinct();

                foreach (var eventDate in eventDates)
                {
                    stringBuilder.AppendFormat("<dt>{0}</dt>", eventDate.Date.ToString("MMM d"));

                    var currentDate = eventDate.Date;

                    var eventsOnDate = from EventEntry e in calendarFeed.Entries
                                       where e.Times.Count > 0
                                       where e.Times[0].StartTime.Date.Equals(currentDate)
                                       where !String.IsNullOrWhiteSpace(e.Title.Text)
                                       orderby e.Times[0].StartTime
                                       select e;

                    stringBuilder.AppendFormat("<dd class=\"vcalendar\">");

                    foreach (var e in eventsOnDate)
                    {
                        stringBuilder.AppendFormat("<span class=\"vevent\"><abbr class=\"dtstart\" title=\"{0}\">{1}</abbr> : <span class=\"summary\">{2}</span></span><br />",
                            e.Times[0].StartTime.ToString("s"),
                            e.Times[0].StartTime.ToString("h tt"),
                            e.Title.Text);
                    }

                    stringBuilder.AppendFormat("</dd>");
                }
            }
            catch (WebException)
            {
            }
            catch (GDataRequestException)
            {
            }
            finally
            {
                stringBuilder.AppendLine("</dl>");
            }

            return stringBuilder.ToString();
        }

        #endregion Properties
    }
}