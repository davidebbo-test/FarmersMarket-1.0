namespace FarmersMarket.Web
{
    using System;
    using System.Web.UI;

    public partial class CurrentVersion : MasterPage
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //scriptManager.Scripts.Add(new ScriptReference("http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.min.js"));

            //scriptManager.CompositeScript.Scripts.Add(new ScriptReference("~/Scripts/gajs.min.js"));
            //scriptManager.CompositeScript.Scripts.Add(new ScriptReference("~/Scripts/jquery-1.3.2.min.js"));
            //scriptManager.CompositeScript.Scripts.Add(new ScriptReference("http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"));
            //scriptManager.Scripts.Add(new ScriptReference("http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"));

            //scriptManager.Scripts.Add(new ScriptReference("~/Scripts/prototype-1.6.0.3.js"));
            //scriptManager.Scripts.Add(new ScriptReference("~/Scripts/sevenup.0.2.min.js"));
            //scriptManager.Scripts.Add(new ScriptReference("~/Scripts/jquery-ext.js")););

            if (!IsPostBack)
            {
                if (Request.Path.EndsWith("/"))
                {
                    htmlHead.InnerHtml += String.Format("<link rel=\"canonical\" href=\"{0}default.aspx\" />",
                        Request.Path);
                }
            }
        }

        protected void SearchSite(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("http://www.google.com/cse?cx=009555136529380750867%3Ac4whwtabsae&ie=UTF-8&q={0}&sa=Search",
                searchBox.Text));
        }

        #endregion Methods
    }
}