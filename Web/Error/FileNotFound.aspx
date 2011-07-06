<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileNotFound.aspx.cs" Inherits="FarmersMarket.Web.Error.FileNotFound"
	MasterPageFile="~/CurrentVersion.Master" Title="Error - Page not found" %>

<%@ Import Namespace="FarmersMarket.Web" %>
<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>Error &ndash; Page not found</h1>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<jfl:Mission ID="mission" runat="server" />
	<jfl:Donate ID="donate" runat="server" />
</asp:Content>
