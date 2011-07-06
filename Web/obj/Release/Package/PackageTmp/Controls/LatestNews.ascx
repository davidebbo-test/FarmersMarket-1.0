<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestNews.ascx.cs"
	Inherits="FarmersMarket.Web.Controls.LatestNews" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<asp:Repeater ID="itemRepeater" runat="server">
	<HeaderTemplate>
		<div style='text-align: left'>
			<h2>
				In the News</h2>
	</HeaderTemplate>
	<ItemTemplate>
		<p>
			<small><strong>
				<%# ((SyndicationItem)(Container.DataItem)).PublishDate.ToString("MMM dd") %></strong>
				<asp:HyperLink NavigateUrl="<%# ((SyndicationItem)(Container.DataItem)).Links[0].Uri.ToString() %>" runat="server">
					<%# ((SyndicationItem)(Container.DataItem)).Title.Text %></asp:HyperLink></small></p>
	</ItemTemplate>
	<FooterTemplate>
		</div>
	</FooterTemplate>
</asp:Repeater>
