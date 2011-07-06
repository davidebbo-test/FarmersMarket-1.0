namespace FarmersMarket.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Produce
    {
        #region Fields

        public static List<Produce> Seasons = new List<Produce> {
            new Produce { Name="Apples", Season=MakeSeason("Jul,Aug,Sep,Oct,Nov,Dec")},
            new Produce { Name="Arugula", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov")},
            new Produce { Name="Asparagus", Season=MakeSeason("Apr,May,Jun")},
            new Produce { Name="Basil", Season=MakeSeason("Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov")},
            new Produce { Name="Beans", Season=MakeSeason("Jun,Jul,Aug,Sep")},
            new Produce { Name="Beets", Season=MakeSeason("Mar,Apr,May,Jun,Oct,Nov,Dec")},
            new Produce { Name="Blackberries", Season=MakeSeason("Jun,Jul")},
            new Produce { Name="Blueberries", Season=MakeSeason("May,Jun,Jul")},
            new Produce { Name="Bok Choy", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Oct,Nov,Dec")},
            new Produce { Name="Broccoli", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec")},
            new Produce { Name="Brussel Sprouts", Season=MakeSeason("Jan,Feb,Nov,Dec")},
            new Produce { Name="Butter Beans", Season=MakeSeason("Jul,Aug")},
            new Produce { Name="Cabbages", Season=MakeSeason("Jan,Feb,Mar,Apr,Oct,Nov,Dec")},
            new Produce { Name="Cantaloupes", Season=MakeSeason("Jul,Aug")},
            new Produce { Name="Cilantro", Season=MakeSeason("May,Jun")},
            new Produce { Name="Collards", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Sep,Oct,Nov,Dec")},
            new Produce { Name="Cucumbers", Season=MakeSeason("Jun,Jul,Aug,Sep")},
            new Produce { Name="Eggplant", Season=MakeSeason("May,Jun,Jul,Aug,Sep,Oct,Nov")},
            new Produce { Name="Figs", Season=MakeSeason("Aug,Sep")},
            new Produce { Name="Elephant Garlic", Season=MakeSeason("Oct,Nov,Dec")},
            /* new Produce { Name="Honeydew", Season=MakeSeason("Jul,Aug")}, */
            new Produce { Name="Kales", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Sep,Oct,Nov,Dec")},
            new Produce { Name="Lettuces", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Jun,Sep,Oct,Nov,Dec")},
            new Produce { Name="Mushrooms", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec")},
            new Produce { Name="Okra", Season=MakeSeason("Jul,Aug,Sep")},
            new Produce { Name="Peaches", Season=MakeSeason("Jun,Jul,Aug")},
            new Produce { Name="Peas", Season=MakeSeason("May,Jun,Jul")},
            new Produce { Name="Bell Peppers", Season=MakeSeason("Jun,Jul,Aug,Sep,Oct")},
            new Produce { Name="Hot Peppers", Season=MakeSeason("Jul,Aug,Sep,Oct")},
            new Produce { Name="Irish Potatoes", Season=MakeSeason("Jan,Feb,Mar,Apr,Jul,Aug,Sep,Oct,Nov,Dec")},
            new Produce { Name="Sweet Potatoes", Season=MakeSeason("Jan,Feb,Mar,Apr,Oct,Nov,Dec")},
            new Produce { Name="Pumpkins", Season=MakeSeason("Jan,Feb,Sep,Oct,Nov,Dec")},
            new Produce { Name="Radishes", Season=MakeSeason("Mar,Apr,May,Jun,Sep,Oct,Nov")},
            /* new Produce { Name="Rutabaga", Season=MakeSeason("Jan,Feb,Mar,Apr,Oct,Nov,Dec")}, */
            new Produce { Name="Scallions", Season=MakeSeason("Mar,Apr,May,Jun")},
            new Produce { Name="Spinach", Season=MakeSeason("Mar,Apr,May,Oct,Nov,Dec")},
            /* new Produce { Name="Sprite Melons", Season=MakeSeason("Jul,Aug")}, */
            /* new Produce { Name="Sprouts", Season=MakeSeason("Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec")}, */
            new Produce { Name="Summer Squash", Season=MakeSeason("Jun,Jul,Aug,Sep,Oct")},
            new Produce { Name="Winter Squash", Season=MakeSeason("Jan,Feb,Mar,Apr,Aug,Sep,Oct,Nov,Dec")},
            new Produce { Name="Strawberries", Season=MakeSeason("Apr,May,Jun")},
            new Produce { Name="Sweet Corn", Season=MakeSeason("Jun,Jul")},
            new Produce { Name="Swiss Chard", Season=MakeSeason("Mar,Apr,May,Jun,Sep,Oct,Nov")},
            new Produce { Name="Tomatoes", Season=MakeSeason("Mar,Apr,May,Jun,Jul,Aug,Oct,Nov,Dec")},
            new Produce { Name="Turnips", Season=MakeSeason("Jan,Feb,Mar,Oct,Nov,Dec")},
            new Produce { Name="Watermelon", Season=MakeSeason("Jun,Jul,Aug")},
        };

        #endregion Fields

        #region Properties

        public string Name
        {
            get; set;
        }

        protected ushort Season
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public static List<String> InSeasonOn(DateTime date)
        {
            var month = (ushort)(1 << (date.Month - 1));
            return (from produce in Seasons where (produce.Season & month) == month select produce.Name).ToList();
        }

        public bool InSeasonForMonth(int month)
        {
            return (((ushort)(1 << (month - 1)) & Season) != 0);
        }

        private static ushort MakeSeason(string months)
        {
            ushort season = 0;

            for (int i = 1; i <= 12; i++)
            {
                if (months.Contains(new DateTime(DateTime.Today.Year, i, 1).ToString("MMM")))
                {
                    season |= (ushort)(1 << (i - 1));
                }
            }

            return season;
        }

        #endregion Methods
    }
}