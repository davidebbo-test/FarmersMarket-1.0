<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Learn.Default"
	MasterPageFile="~/CurrentVersion.Master" Title="Learn more about the Western Wake Farmers’ Market" %>

<%@ Import Namespace="FarmersMarket.Web" %>
<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<jfl:FeedContent ID="feedContent" Category="learn" HandleSplit="true" MaxResults="100" 
    ShowAge="true" ShowAuthor="true" ShowHeadingAsLink="true" runat="server" />
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<jfl:Mission ID="mission" runat="server" />
	<jfl:Donate ID="donate" runat="server" />
	<!--
	<p>
		<img id="snapshot" runat="server" alt="North Carolina Produce" src="~/Images/assorted_veggies-2.jpg"
			style="width: 100%" /></p>
	-->
</asp:Content>
