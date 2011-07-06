using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FarmersMarket.Web.Vendors.Applications
{
    using Helpers;

    public partial class Browse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VendorNameToFile = new SortedDictionary<String, String>();
            VendorNameToApplication = new SortedDictionary<String, VendorApplication>();

            var path = Server.MapPath(Path.GetDirectoryName(Request.Path));

            foreach (var applicationXmlFile in
                Directory.EnumerateFiles(path, "*.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(VendorApplication));
                
                using (var textReader = new StreamReader(applicationXmlFile))
                {
                    var vendorApplication = xmlSerializer.Deserialize(textReader) as VendorApplication;
                    if (vendorApplication == null) continue;

                    var fileName = Path.GetFileNameWithoutExtension(applicationXmlFile);

                    if (String.IsNullOrEmpty(fileName)) continue;

                    if (VendorNameToFile.ContainsKey(vendorApplication.Name)) continue;

                    VendorNameToFile.Add(vendorApplication.Name, fileName);
                    VendorNameToApplication.Add(vendorApplication.Name, vendorApplication);
                }
            }
        }

        protected SortedDictionary<String, String> VendorNameToFile;
        protected SortedDictionary<String, VendorApplication> VendorNameToApplication;
    }
}
