<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.About"
	MasterPageFile="~/CurrentVersion.Master" Title="About the Western Wake Farmers’ Market" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<jfl:FeedContent ID="feedContent" Category="about" HandleSplit="true" 
        ShowAge="true" ShowAuthor="true" ShowHeadingAsLink="true" runat="server" />
    <!--
	<h2>
		Latest News</h2>
	<div id="pipe">
		<jfl:PipeContent ID="pipeContent" Uri="http://pipes.yahoo.com/pipes/pipe.run?_id=kI8SdkAA3hGgIAS_PxJ3AQ&_render=rss"
			runat="server" />
	</div>
    -->
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<jfl:Donate ID="donate" runat="server" />
	<!--
	<p>
		<img id="snapshot" runat="server" alt="North Carolina Produce" src="~/Images/assorted_veggies-2.jpg"
			style="width: 100%" /></p>
	-->
</asp:Content>
