<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="FarmersMarket.Web.Vendors.Applications.Detail" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%: VendorApp.Name %></title>
    <style type="text/css">
        #detailForm { text-align: left; }
        ul#products { list-style-type: none; }
        ul#products { display: inline-block; }
        table#marketCalendar tr td { padding: 0.5em 1em; text-align: right; }
        table#marketCalendar tr td.accepted { background-color: #fff; }
        table#marketCalendar tr td.declined { background-color: #ddd; color: #666; }
    </style>
</head>
<body>
    <form id="detailForm" runat="server">
        <div>
            <h1><%: VendorApp.Name %></h1>
            <p><%: VendorApp.Description %></p>
            <h3>Products</h3>
            <ul id="products">
            <% foreach (var product in VendorApp.Products)
               { %>
                    <li>
                        <%: String.Format("{0}, ", product) %>
                    </li>
            <% } %>
            </ul>
            <asp:Table ID="marketCalendar" runat="server" CssClass="marketDates">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell ColumnSpan="6">Market Dates</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
