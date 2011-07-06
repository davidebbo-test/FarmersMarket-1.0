<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Vendors.Applications.Browse" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <title>Vendor Applications</title>
    <style type="text/css">
    #browseForm { text-align: left; }
    </style>
</head>
<body>
    <form id="browseForm" runat="server">
    <div>
        <ul>
        <% foreach (var tuple in VendorNameToFile)
           {
               var vendorApp = VendorNameToApplication[tuple.Key];
               %>
            <li>
                <a href="<%= String.Format("{0}?file={1}", "Detail.aspx", tuple.Value) %>"
                        title="<%= vendorApp.Description %>">
                    <%: vendorApp.Name %>
                </a>
            </li>
        <% } %>
        </ul>
    </div>
    </form>
</body>
</html>
