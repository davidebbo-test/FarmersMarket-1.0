<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Post"
    MasterPageFile="~/CurrentVersion.Master" Title="Western Wake Farmers’ Market in Cary, NC" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <title><%: Item.Title.Text %></title>
    <meta name="description" content="Latest news about the Western Wake Farmers' Market, open Saturdays, April through November at Carpenter Village in Cary, NC" />
    <meta name="keywords" content="cary,wake county,carpenter village,farmers market,local food,locavore,news" />
</asp:Content>

<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1><%: Item.Title.Text %></h1>
    <p class="vcard">Posted by 
        <a class="url fn" href="<%= Item.Authors[0].Uri %>">
            <%: Item.Authors[0].Name %></a>
        <abbr class='published' title='<%=Item.PublishDate.DateTime.ToString("F") %>'>
            <%= Item.PublishDate.DateTime.ToRelativeDate() %></abbr>
    </p>
    <div><%= ((TextSyndicationContent)(Item.Content)).Text %>
    </div>

    <div id="fb-root"></div>
    <script src="http://connect.facebook.net/en_US/all.js#appId=205698539440426&amp;xfbml=1" type="text/javascript"></script>
    <p><fb:like href="<%= Request.Url %>" font="Segoe UI"></fb:like></p>
</asp:Content>
