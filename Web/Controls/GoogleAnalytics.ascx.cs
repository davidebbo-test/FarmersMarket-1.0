namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Web.Configuration;

    public partial class GoogleAnalytics : System.Web.UI.UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterGoogleAnalyticsScript();
            }
        }

        protected void RegisterGoogleAnalyticsScript()
        {
            const String googleAnalyticsJavascript =
            @"
            <script type='text/javascript'>
            var gaJsHost = (('https:' == document.location.protocol) ? 'https://ssl.' : 'http://www.');
            document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
            </script>

            <script type='text/javascript'>
            try {{
            var pageTracker = _gat._getTracker('{0}');
            pageTracker._trackPageview();
            }} catch (err) {{ }}
            </script>
            ";
            String analyticsKey = WebConfigurationManager.AppSettings["GoogleAnalyticsKey"];

            if (!String.IsNullOrEmpty(analyticsKey))
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("GoogleAnalytics"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(GoogleAnalytics), "GoogleAnalytics",
                        String.Format(googleAnalyticsJavascript, analyticsKey));
                }
            }
        }

        #endregion Methods
    }
}