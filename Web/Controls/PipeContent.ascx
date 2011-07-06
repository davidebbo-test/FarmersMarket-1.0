<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PipeContent.ascx.cs"
	Inherits="FarmersMarket.Web.Controls.PipeContent" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<asp:Repeater ID="itemRepeater" runat="server">
	<ItemTemplate>
		<h4>
			<asp:HyperLink NavigateUrl="<%# ((SyndicationItem)(Container.DataItem)).Links[0].Uri %>" runat="server">
				<%# ((SyndicationItem)(Container.DataItem)).Title.Text %></asp:HyperLink></h4>
		<p>
			<%# ((SyndicationItem)(Container.DataItem)).Summary.Text %>
		</p>
	</ItemTemplate>
</asp:Repeater>
