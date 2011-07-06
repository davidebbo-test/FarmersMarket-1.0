namespace FarmersMarket.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Web.Caching;
    using System.Xml;

    /// <summary>
    /// Implements a syndication feed whose contents are cached on a rolling
    /// expiration period (default is 5 minutes)
    /// </summary>
    public class CachedFeed
    {
        #region Fields

        readonly Cache _cache;
        readonly Uri _uri;

        #endregion Fields

        #region Constructors

        public CachedFeed(string url, Cache cache)
        {
            _uri = new Uri(url);
            _cache = cache;
            Expiration = TimeSpan.FromMinutes(5);
        }

        #endregion Constructors

        #region Properties

        public TimeSpan Expiration
        {
            get; set;
        }

        public IEnumerable<SyndicationItem> Items
        {
            get
            {
                var items = (IEnumerable<SyndicationItem>)(_cache[_uri.ToString()]);

                if (items == null)
                {
                    try
                    {
                        var webClient = new WebClient
                                            {
                                                Proxy = WebRequest.GetSystemWebProxy(),
                                                Credentials = CredentialCache.DefaultCredentials
                                            };

                        using (var streamFeed = webClient.OpenRead(_uri))
                        {
                            var reader = XmlReader.Create(streamFeed);
                            var feed = SyndicationFeed.Load(reader);

                            if (feed != null)
                                items = from item in feed.Items
                                        orderby item.PublishDate descending
                                        select item;

                            reader.Close();
                        }
                    }
                    catch (XmlException)
                    {
                        items = new List<SyndicationItem>();
                    }
                    catch (WebException)
                    {
                        items = new List<SyndicationItem>();
                    }

                    if (items != null)
                        _cache.Add(_uri.ToString(), items, null, Cache.NoAbsoluteExpiration,
                                   TimeSpan.FromMinutes(5), CacheItemPriority.Normal, null);
                }

                return items ?? new List<SyndicationItem>();
            }
        }

        #endregion Properties
    }
}