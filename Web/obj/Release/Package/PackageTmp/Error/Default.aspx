<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Error.Default"
	MasterPageFile="~/CurrentVersion.Master" Title="Error" %>

<%@ Import Namespace="FarmersMarket.Web" %>
<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>Error</h1>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<jfl:Mission ID="mission" runat="server" />
	<jfl:Donate ID="donate" runat="server" />
</asp:Content>
