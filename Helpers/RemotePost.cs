using System;
namespace FarmersMarket.Helpers
{
    public class RemotePost
    {
        #region Fields

        public string FormName = "form1";
        public string Method = "post";
        public string Url = "";

        private readonly System.Collections.Specialized.NameValueCollection _inputs = 
            new System.Collections.Specialized.NameValueCollection();

        #endregion Fields

        #region Methods

        public void Add(string name, string value)
        {
            _inputs.Add(name, value);
        }

        public void Post()
        {
            System.Web.HttpContext.Current.Response.Clear();

            System.Web.HttpContext.Current.Response.Write( "<html><head>" );

            System.Web.HttpContext.Current.Response.Write(
                String.Format( "</head><body onload=\"document.{0}.submit()\">" ,FormName));

            System.Web.HttpContext.Current.Response.Write(
                String.Format( "<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >" ,

            FormName,Method,Url));

            for (int i = 0; i< _inputs.Keys.Count; i++)
            {
                System.Web.HttpContext.Current.Response.Write(
                    String.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">",
                    _inputs.Keys[i],_inputs[_inputs.Keys[i]]));
            }

            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body></html>");
            System.Web.HttpContext.Current.Response.End();
        }

        #endregion Methods
    }
}