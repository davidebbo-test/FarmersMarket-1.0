namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel.Syndication;

    using FarmersMarket.Helpers;

    public partial class LatestNews : System.Web.UI.UserControl
    {
        #region Fields

        private string _url;

        #endregion Fields

        #region Properties

        public string FeedUrl
        {
            set
            {
                _url = value;
            }
        }

        protected IEnumerable<SyndicationItem> Items
        {
            get
            {
                var feed = new CachedFeed(_url, Cache);
                var items = feed.Items;

                return items ?? new List<SyndicationItem>();
            }
        }

        #endregion Properties

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                itemRepeater.DataSource = Items;
                DataBind();
            }
        }

        #endregion Methods
    }
}