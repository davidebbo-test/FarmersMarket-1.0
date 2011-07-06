namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Web.Caching;
    using System.Xml;

    public partial class PipeContent : System.Web.UI.UserControl
    {
        #region Fields

        private string _uri;

        #endregion Fields

        #region Constructors

        public PipeContent()
        {
            Load += PageLoad;
        }

        #endregion Constructors

        #region Properties

        public string Uri
        {
            set
            {
                _uri = value;
            }
        }

        IEnumerable<SyndicationItem> Items
        {
            get
            {
                var items = (IEnumerable<SyndicationItem>)Cache[_uri];
                if (items != null) return items;

                try
                {
                    var reader = XmlReader.Create(_uri);
                    var feed = SyndicationFeed.Load(reader);

                    if (feed != null)
                        items = from item in feed.Items
                                orderby item.PublishDate descending
                                select item;

                    reader.Close();
                }
                catch (XmlException)
                {
                    items = new List<SyndicationItem>();
                }

                if (items != null)
                {
                    Cache.Add(_uri, items, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5),
                              CacheItemPriority.Normal, null);
                }

                return items;
            }
        }

        #endregion Properties

        #region Methods

        protected void PageLoad(object sender, EventArgs e)
        {
            itemRepeater.DataSource = Items;
            DataBind();
        }

        #endregion Methods
    }
}