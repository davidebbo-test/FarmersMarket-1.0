<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Sponsors"
	MasterPageFile="~/CurrentVersion.Master" Title="Who sponsors the Western Wake Farmers’ Market?" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<jfl:FeedContent ID="feedContent" Category="sponsors" ShowAge="true" ShowAuthor="true" runat="server" />
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<jfl:Mission ID="mission" runat="server" />
	<jfl:Donate ID="donate" runat="server" />
</asp:Content>
