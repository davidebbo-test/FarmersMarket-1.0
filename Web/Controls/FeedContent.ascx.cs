namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Text;

    using Helpers;

    public partial class FeedContent : System.Web.UI.UserControl
    {
        #region Fields

        private int _headingLevel = 1;
        private int _maxResults = 10;
        private String _category = String.Empty;
        private FeedStyle _style = FeedStyle.Bare;
        private String _url;
        private readonly String _blogId;

        #endregion Fields

        #region Constructors

        public FeedContent()
        {
            Load += PageLoad;

            _blogId = ConfigurationManager.AppSettings["BlogId"];
        }

        #endregion Constructors

        #region Enumerations

        [Flags]
        public enum FeedStyle : short
        {
            Bare = 0x00,
            Author = 0x01,
            Age = 0x02,
            Link = 0x04,
        }

        #endregion Enumerations

        #region Properties

        public String Category
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _category = value;
                    UpdateUrl();
                }
            }
        }

        public String FeedUrl
        {
            set
            {
                _url = value;
            }
        }

        public bool HandleSplit { get; set; }

        public int HeadingLevel
        {
            set
            {
                _headingLevel = value;
            }
        }

        public int MaxResults
        {
            set 
            { 
                _maxResults = value;
                UpdateUrl();
            }
        }

        public bool ShowAge
        {
            set
            {
                if (value)
                {
                    _style |= FeedStyle.Age;
                }
                else
                {
                    _style &= ~FeedStyle.Age;
                }
            }
        }

        public bool ShowAuthor
        {
            set
            {
                if (value)
                {
                    _style |= FeedStyle.Author;
                }
                else
                {
                    _style &= ~FeedStyle.Author;
                }
            }
        }

        public bool ShowHeadingAsLink
        {
            set
            {
                if (value)
                {
                    _style |= FeedStyle.Link;
                }
                else
                {
                    _style &= ~FeedStyle.Link;
                }
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

        protected String GetContent(SyndicationItem item)
        {
            var contentText = String.Empty;

            if (item.Content != null)
                contentText = ((TextSyndicationContent)(item.Content)).Text;
            else if (item.Summary != null)
                contentText = item.Summary.Text;

            // remove blogspot.com footer
            int footerPos = contentText.IndexOf("<div class=\"blogger-post-footer\">");

            if (footerPos > 1)
            {
                contentText = contentText.Substring(0, footerPos);
            }

            if (HandleSplit)
            {
                int splitPos = contentText.IndexOf("<a name='more'></a>");

                if (splitPos > 1)
                {
                    contentText = contentText.Substring(0, splitPos);

                    contentText += String.Format(
                        "<p class=\"{1}\"><a href=\"{0}#more\">Read more »</a></p>",
                        GetPostUrl(item), "split");
                }
            }

            if (String.IsNullOrEmpty(contentText)) return String.Empty;
            return String.Format("<div>{0}</div>", contentText);
        }

        protected String GetSubtitle(SyndicationItem item)
        {
            if (_style == FeedStyle.Bare) return String.Empty;

            var subtitle = new StringBuilder("Posted");

            if (_style.HasFlag(FeedStyle.Author)) {
                subtitle.AppendFormat(" by <a class='url fn' href='{0}'>{1}</a>",
                    item.Authors[0].Uri, item.Authors[0].Name);
            }

            if (_style.HasFlag(FeedStyle.Age)) {
                subtitle.AppendFormat(" <abbr class='published' title='{0}'>{1}</abbr>",
                    item.PublishDate.DateTime.ToString("F"), item.PublishDate.DateTime.ToRelativeDate());
            }

            return subtitle.ToString();
        }

        protected String GetTitle(SyndicationItem item)
        {
            if (_style.HasFlag(FeedStyle.Link))
            {
                return String.Format("<h{1}><a href=\"{2}\">{0}</a></h{1}>",
                    item.Title.Text, _headingLevel, GetPostUrl(item));
            }

            return String.Format("<h{1}>{0}</h{1}>", item.Title.Text, _headingLevel);
        }

        protected void PageLoad(object sender, EventArgs e)
        {
            itemRepeater.DataSource = Items;
            DataBind();
        }

        private String GetPostUrl(SyndicationItem item)
        {
            var selfUrl = (from SyndicationLink link in item.Links
                           where link.RelationshipType.Equals("self")
                           select link.Uri).First();

            var postId = selfUrl.ToString().Substring(selfUrl.ToString().LastIndexOf('/') + 1);
            return Page.ResolveUrl(String.Format("~/Post/{0}", postId));
        }
        
        private void UpdateUrl()
        {
            _url = String.Format("http://www.blogger.com/feeds/{0}/posts/default/-/{1}?max-results={2}", 
                _blogId, _category, _maxResults);
           
        }

        #endregion Methods
    }
}