namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Web.UI;

    public partial class NavigationTabs : UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri url = Page.Request.Url;
                string path = url.AbsolutePath;

                if (path.IndexOf(seasonTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    seasonTab.CssClass = "active";
                }
                else if (path.IndexOf(sponsorsTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    sponsorsTab.CssClass = "active";
                }
                else if (path.IndexOf(vendorsTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    vendorsTab.CssClass = "active";
                }
                else if (path.IndexOf(recipeTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    recipeTab.CssClass = "active";
                }
                else if (path.IndexOf(aboutTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    aboutTab.CssClass = "active";
                }
                else if (path.IndexOf(contactTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    contactTab.CssClass = "active";
                }
                else if (path.IndexOf(newsletterTab.NavigateUrl.Substring(1), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    newsletterTab.CssClass = "active";
                }
                else
                {
                    homeTab.CssClass = "active";
                }
            }
        }

        #endregion Methods
    }
}