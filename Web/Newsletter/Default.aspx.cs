using System.IO;
using System.Linq;
using System.Net;

namespace FarmersMarket.Web.Newsletter
{
    using System;
    using System.Diagnostics;

    using ConstantContact;

    public partial class Default : System.Web.UI.Page
    {
        #region Fields

        private ConstantContactCredential _constantContactCredential;

        #endregion Fields

        #region Properties

        protected ConstantContactCredential ConstantContactCredential
        {
            get
            {
                if (_constantContactCredential == null)
                {
                    const string apiKey = "de290411-5611-4cf0-85c0-e01c8cbaac14";
                    const string customerUserName = "wwfmarket";
                    const string customerPassword = "sustainable09";

                    _constantContactCredential = new ConstantContactCredential(
                        apiKey, customerUserName, customerPassword);
                }

                return _constantContactCredential;
            }
        }

        #endregion Properties

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Entering Page_Load");

            string postBackReference = ClientScript.GetPostBackEventReference(
                SubscribeButton, String.Empty);

            SubscribeButton.OnClientClick = "if (Page_ClientValidate())" +
                "{ this.style.display='none'; document.getElementById('WorkingMessage').style.display=''; " +
                postBackReference + " };";

            if (!IsPostBack)
            {
                FirstNameText.Focus();
            }
            else
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    SubscribeUser(SubscribeButton, EventArgs.Empty);
                }
            }
        }

        protected void SubscribeUser(object sender, EventArgs e)
        {
            NewsletterSignup.Visible = false;
            /*
            var remotePost = new RemotePost
                                 {
                                     Url = "http://visitor.constantcontact.com/d.jsp"
                                 };

            remotePost.Add("m", "1102557664784");
            remotePost.Add("p", "oi");
            remotePost.Add("ea", EmailAddressText.Text);
            remotePost.Post();
            */
            var generalInterestList = new ContactList("/ws/customers/wwfmarket/lists/1")
            {
                OptInSource = OptInSource.ACTION_BY_CONTACT,
                OptInTime = DateTimeOffset.Now
            };

            try
            {
                Contact contact = ContactsCollection.GetContactByEmail(
                    ConstantContactCredential, EmailAddressText.Text);

                if (contact == null)
                {
                    contact = new Contact
                                  {
                                      Status = ContactStatus.Active,
                                      FirstName = FirstNameText.Text,
                                      LastName = LastNameText.Text,
                                      EmailAddress = EmailAddressText.Text,
                                      OptInSource = OptInSource.ACTION_BY_CONTACT
                                  };

                    contact.Lists.Add(generalInterestList);
                    ContactsCollection.CreateContact(ConstantContactCredential, contact);

                    ResultHtml.Text = GetLocalResourceObject("ThankYou").ToString();
                }
                else
                {
                    var generalInterestUri = generalInterestList.Link.ToLower();

                    if (contact.Lists.Any(list => String.Compare(list.Link, generalInterestUri, true) == 0))
                    {
                        ResultHtml.Text = GetLocalResourceObject("AlreadySubscribed").ToString();
                        return;
                    }

                    contact.Lists.Add(generalInterestList);
                    ContactsCollection.UpdateContact(ConstantContactCredential, contact);

                    ResultHtml.Text = GetLocalResourceObject("ThankYou").ToString();
                }

            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                { 
                    var errorMessage = (new StreamReader(
                        webException.Response.GetResponseStream())).ReadToEnd();

                    ResultHtml.Text = Server.HtmlEncode(String.Format("{0}: {1}{2}",
                               webException.Status,
                               errorMessage,
                               Environment.NewLine));
                }
                else
                {
                    ResultHtml.Text = String.Format(
                        GetLocalResourceObject("SubscribeErrorFormat").ToString(),
                        webException.Message);
                }
            }

            ResultPanel.Visible = true;
            MetaRefresh.Attributes["HTTP-EQUIV"] = "refresh";
            MetaRefresh.Attributes["content"] = "3;URL=" + Page.ResolveUrl("~/");
        }

        #endregion Methods
    }
}