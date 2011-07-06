using System.Web.Routing;

namespace FarmersMarket.Web
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Web;
    using System.Web.UI;

    public class Global : HttpApplication
    {
        #region Methods

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Logs the Error event to the application event log.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            /*
            var ex = Server.GetLastError();
            var mail = new MailMessage();

            mail.To.Add(new MailAddress("jimlamb@westernwakefarmersmarket.org", "Jim Lamb"));
            mail.From = new MailAddress("system@westernwakefarmersmarket.org", typeof(Global).Namespace);
            mail.Subject = ex.Message;

            var bodyBuilder = new StringBuilder();
            //ex.
            bodyBuilder.AppendFormat("{0}{1}", ex.Source, Environment.NewLine);
            bodyBuilder.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
            bodyBuilder.AppendFormat("{0}{1}", ex.StackTrace, Environment.NewLine);

            mail.Body = bodyBuilder.ToString();
            mail.IsBodyHtml = false;

            var smtp = new SmtpClient
                           {
                               Host = ConfigurationManager.AppSettings["SMTP"],
                               Credentials = new System.Net.NetworkCredential(
                                   ConfigurationManager.AppSettings["FROMEMAIL"],
                                   ConfigurationManager.AppSettings["FROMPWD"]),
                               EnableSsl = true
                           };

            try
            {
                smtp.Send(mail);
            }
            catch (SmtpException)
            {
            }
            */
        }

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This event gets fired just before ASP.net starts handling a request.
        /// If a client browser supports compressed content streams (which most 
        /// browsers do) of the types, Gzip and Deflate, the value of this header 
        /// will contain them. A reference to current uncompressed output Stream 
        /// object used by ASP.NET to send the plain text (or binary) output to 
        /// the client browser is saved in the prevUncompressedStream object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            if (app != null)
            {
                string acceptEncoding = app.Request.Headers["Accept-Encoding"];
                Stream prevUncompressedStream = app.Response.Filter;

                if (!(app.Context.CurrentHandler is Page) ||
                    app.Request["HTTP_X_MICROSOFTAJAX"] != null)
                    return;

                if (string.IsNullOrEmpty(acceptEncoding))
                    return;

                acceptEncoding = acceptEncoding.ToLower();

                if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
                {
                    // defalte
                    app.Response.Filter = new DeflateStream(prevUncompressedStream,
                                                            CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "deflate");
                }
                else if (acceptEncoding.Contains("gzip"))
                {
                    // gzip
                    app.Response.Filter = new GZipStream(prevUncompressedStream,
                                                         CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "gzip");
                }
            }
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("posts", "Post/{id}", "~/Post.aspx");
        }

        #endregion Methods
    }
}