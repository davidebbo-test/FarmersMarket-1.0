<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedContent.ascx.cs"
	Inherits="FarmersMarket.Web.Controls.FeedContent" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<asp:Repeater ID="itemRepeater" runat="server">
	<ItemTemplate>
		<%# GetTitle((SyndicationItem)(Container.DataItem))%>
		<p class="vcard">
			<%# GetSubtitle((SyndicationItem)(Container.DataItem)) %>
		</p>
		<%# GetContent((SyndicationItem)(Container.DataItem)) %>
	</ItemTemplate>
</asp:Repeater>
