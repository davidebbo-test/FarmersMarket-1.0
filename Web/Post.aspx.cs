/*
http://www.blogger.com/feeds/7916832134968916231/posts/default/2824554974835089581
71950586112053749
Id: "tag:blogger.com,1999:blog-7916832134968916231.post-2824554974835089581"

<?xml version='1.0' encoding='UTF-8'?>
<?xml-stylesheet href="http://www.blogger.com/styles/atom.css" type="text/css"?>
<entry xmlns='http://www.w3.org/2005/Atom' xmlns:georss='http://www.georss.org/georss' xmlns:thr='http://purl.org/syndication/thread/1.0'>
  <id>tag:blogger.com,1999:blog-7916832134968916231.post-2824554974835089581</id>
  <published>2011-02-16T15:13:00.000-08:00</published>
  <updated>2011-02-16T19:19:09.925-08:00</updated>
  <category scheme='http://www.blogger.com/atom/ns#' term='home'/>
  <title type='text'>Another Advantage of Buying Local</title>
  <content type='html'>&lt;em&gt;Written by Kevin Gordon, Professional Market Shopper&lt;/em&gt;&lt;br /&gt;&lt;br /&gt;Not that I really needed another reason to appreciate the benefits of buying local, but I've had some recent experiences at the market that have really reminded me of why shopping local beats going to the supermarket anyday.&lt;br /&gt;&lt;br /&gt;My family has been trying recently to remove sugar from our diet, which is pretty hard to do even if you avoid most processed foods.  Not surprisingly, my kids really love some of the "sweet" things at the market. In particular, the fabulous jams and jellies from Shelly Mac Farm.  I decided to talk to Shelby McKenzie of Shelly Mac about my dilemma and she said she would look into making some jam with honey instead of sugar. The very next Saturday, Shelby brought some peach jam made with honey! She went even further the next weekend and made another batch without pectin, since I found out that commercial pectin has dextrose (another form of sugar).&lt;br /&gt;&lt;br /&gt;Good luck getting customer service like this from Smuckers. Shelby's latest concoction this past weekend was an incredible apple butter made with apples from Godwin Orchards and honey from East Wake Apiaries.  Now my kids want to put apple butter on everything, including their fingers.&lt;br /&gt;&lt;br /&gt;Don't be afraid to talk with your farmers' market vendors about something new or different that you would like to see from them, or even to offer feedback on existing products. That's the advantage of the direct, face-to-face relationship that you get when buying local at a farmers' market.&lt;div class="blogger-post-footer"&gt;&lt;img width='1' height='1' src='https://blogger.googleusercontent.com/tracker/7916832134968916231-2824554974835089581?l=westernwakefarmersmarket.blogspot.com' alt='' /&gt;&lt;/div&gt;</content>
  <link rel='replies' type='application/atom+xml' href='http://westernwakefarmersmarket.blogspot.com/feeds/2824554974835089581/comments/default' title='Post Comments'/>
  <link rel='replies' type='text/html' href='http://westernwakefarmersmarket.blogspot.com/2011/02/another-advantage-of-buying-local.html#comment-form' title='0 Comments'/>
  <link rel='edit' type='application/atom+xml' href='http://www.blogger.com/feeds/7916832134968916231/posts/default/2824554974835089581'/>
  <link rel='self' type='application/atom+xml' href='http://www.blogger.com/feeds/7916832134968916231/posts/default/2824554974835089581'/>
  <link rel='alternate' type='text/html' href='http://westernwakefarmersmarket.blogspot.com/2011/02/another-advantage-of-buying-local.html' title='Another Advantage of Buying Local'/>
  <author>
    <name>Kim Hunter</name>
    <uri>http://www.blogger.com/profile/13790786981658619260</uri>
    <email>noreply@blogger.com</email>
    <gd:extendedProperty xmlns:gd='http://schemas.google.com/g/2005' name='OpenSocialUserId' value='07939020734642729279'/>
  </author>
  <thr:total>0</thr:total>
</entry>
*/

namespace FarmersMarket.Web
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Xml;
    using System.Xml.Linq;

    public partial class Post : System.Web.UI.Page
    {
        #region Fields

        protected SyndicationItem Item;

        #endregion Fields

        #region Constructors

        public Post()
        {
            Load += PageLoad;
        }

        #endregion Constructors

        #region Methods

        protected void PageLoad(object sender, EventArgs e)
        {
            try
            {
                var webClient = new WebClient
                {
                    Proxy = WebRequest.GetSystemWebProxy(),
                    Credentials = CredentialCache.DefaultCredentials
                };

                var blogId = ConfigurationManager.AppSettings["BlogId"];

                var postId = Page.RouteData.Values.ContainsKey("id") ? 
                    Page.RouteData.Values["id"].ToString() : Request.QueryString["id"];

                var postUri =
                    new Uri(String.Format("http://www.blogger.com/feeds/{0}/posts/default/{1}",
                        blogId, postId));

                using (var streamFeed = webClient.OpenRead(postUri))
                {
                    if (streamFeed != null)
                    {
                        var feed = XElement.Load(streamFeed);
                        XNamespace nsAtom = "http://www.w3.org/2005/Atom";

                        Item = (from c in feed.DescendantsAndSelf(nsAtom + "entry")
                                select new SyndicationItem
                                {
                                    Id = (String)c.Element(nsAtom + "id"),
                                    Title = new TextSyndicationContent((String)c.Element(nsAtom + "title") ?? ""),
                                    Content = new TextSyndicationContent((String)c.Element(nsAtom + "content") ?? ""),
                                    PublishDate = new DateTimeOffset(DateTime.Parse((String)c.Element(nsAtom + "published")))
                                }).First();

                        var authors =
                            from a in feed.DescendantsAndSelf(nsAtom + "entry").Elements(nsAtom + "author")
                            select new SyndicationPerson
                                       {
                                           Name = (String) a.Element(nsAtom + "name") ?? String.Empty,
                                           Email = (String) a.Element(nsAtom + "email") ?? String.Empty,
                                           Uri = (String) a.Element(nsAtom + "uri") ?? String.Empty,
                                       };

                        Item.Authors.Add(authors.First());
                    }
                }
            }
            catch (XmlException)
            {
                Item = new SyndicationItem();
            }
            catch (WebException)
            {
                Item = new SyndicationItem();
            }
        }

        #endregion Methods
    }
}