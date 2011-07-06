<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Vendors.Default"
	MasterPageFile="~/CurrentVersion.Master" Title="Vendors for the Western Wake Farmers’ Market" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<jfl:FeedContent ID="feedContent" Category="vendors" ShowAge="true" ShowAuthor="true" runat="server" />
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<p style="margin-top: 1em">
		<a href="Information.aspx">
			<img src="~/Images/new_vendor.png" style="border: 0; width: 213px" runat="server" alt="Become a vendor!" /></a>
	</p>
	<p>Before applying to become a vendor, please review the <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Vendors/Rules.aspx" runat="server">Market Rules</asp:HyperLink>.</p>
</asp:Content>
