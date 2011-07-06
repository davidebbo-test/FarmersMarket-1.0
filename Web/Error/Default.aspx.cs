namespace FarmersMarket.Web.Error
{
    using System;
    using System.Diagnostics;

    public partial class Default : System.Web.UI.Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null) { Debug.WriteLine(ex.Message); }
        }

        #endregion Methods
    }
}