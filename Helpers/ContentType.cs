namespace FarmersMarket.Helpers
{
    using System;
    using System.Globalization;
    using System.Web;

    public class ContentType : IHttpModule
    {
        #region Methods

        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            //application.PreSendRequestHeaders += Application_PreSendRequestHeaders;
        }
/*
        private static void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            // text/html+xhtml1.0
            var app = ((HttpApplication)(sender));
            var context = app.Context;

            if (context.Request.FilePath.EndsWith(".aspx", true, CultureInfo.InvariantCulture))
            {
                string httpAccept = context.Request.ServerVariables["HTTP_ACCEPT"];

                if (httpAccept != null &&
                    (httpAccept.IndexOf("application/xhtml+xml") >= 0))
                {
                    context.Response.ContentType = "application/xhtml+xml";
                }
                else
                {
                    context.Response.ContentType = "text/html";
                }
            }
        }
*/
        #endregion Methods
    }
}