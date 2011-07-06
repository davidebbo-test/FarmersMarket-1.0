namespace FarmersMarket.Web
{
    using System;
    using System.Configuration;
    using System.Net.Mail;
    using System.Text;

    public partial class Contact : System.Web.UI.Page
    {
        #region Fields

        private string _outcome = String.Empty;

        #endregion Fields

        #region Properties

        protected string Outcome
        {
            get
            {
                return _outcome;
            }
        }

        #endregion Properties

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                submitButton.OnClientClick = ClientScript.GetPostBackEventReference(submitButton, "") +
                    "; this.value='Sending...'; this.disabled = true;";
            }
        }

        protected void SendEmail(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var mail = new MailMessage();

                mail.To.Add(new MailAddress("info@westernwakefarmersmarket.org", "Western Wake Farmers' Market"));

                var fromEmail = String.IsNullOrEmpty(emailText.Text) ?
                    "system@westernwakefarmersmarket.org" : emailText.Text;
                var fromName = String.IsNullOrEmpty(nameText.Text) ?
                    "Western Wake Farmers’ Market" : nameText.Text;

                mail.CC.Add(new MailAddress(fromEmail, fromName));

                mail.From = new MailAddress("system@westernwakefarmersmarket.org", fromName);
                mail.ReplyToList.Add(new MailAddress(fromEmail, fromName));
                mail.Subject = "Inquiry from Website Visitor";
                mail.Subject = String.Format("Inquiry from {0}",
                    String.IsNullOrEmpty(nameText.Text) ? "Web site Visitor" : nameText.Text);

                var bodyBuilder = new StringBuilder();
                bodyBuilder.AppendFormat("{0}{1}", messageText.Text, Environment.NewLine);
                bodyBuilder.AppendFormat("----------------------------------{0}", Environment.NewLine);
                bodyBuilder.AppendFormat("This message was generated from a contact form at: {0}{1}",
                    Request.FilePath, Environment.NewLine);
                bodyBuilder.AppendFormat("It was submitted by {0} ({1}){2}",
                    fromName, fromEmail, Environment.NewLine);
                bodyBuilder.AppendFormat("{0}Your contact information was not shared with the user.",
                    Environment.NewLine);

                mail.Body = bodyBuilder.ToString();
                mail.IsBodyHtml = false;

                var smtp = new SmtpClient();

                try
                {
                    smtp.Send(mail);
                    contactForm.Visible = false;
                    heading.InnerText = GetLocalResourceObject("ThankYou").ToString();
                    ackPanel.Visible = true;

                    _outcome = GetLocalResourceObject("Success").ToString();

                    if (String.IsNullOrEmpty(emailText.Text))
                    {
                        _outcome += GetLocalResourceObject("NoEmailProvided").ToString();
                    }
                    else
                    {
                        _outcome += GetLocalResourceObject("EmailProvided").ToString();
                    }

                }
                catch (SmtpException)
                {
                    _outcome = GetLocalResourceObject("MailException").ToString();
                }
            }
        }

        #endregion Methods
    }
}