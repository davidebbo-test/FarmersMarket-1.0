<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Default"
    MasterPageFile="~/CurrentVersion.Master" Title="Western Wake Farmers’ Market in Cary, NC" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Latest news about the Western Wake Farmers' Market, open Saturdays, April through November at Carpenter Village in Cary, NC" />
    <meta name="keywords" content="cary,wake county,carpenter village,farmers market,local food,locavore,news" />

    <script type="text/javascript">
        function hideMission() {
            document.getElementById('mission').style.display = 'none';
            document.cookie = 'hideMission=true; expires=Fri, 30 Aug 2019 23:59:59 UTC; path=/';
        }
    </script>

</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <% if (Request.Cookies["hideMission"] == null)
       { %>
    <div id="mission">
        <p style="font-size: 125%">
            <strong>Our mission</strong> is for all people in our community to become educated
            about and benefit from locally grown food. Our aim is to help <em>all</em> walks
            of life, from the farmers to the local community members to those less fortunate
            who might need assistance through the local food bank. </p>
        <p style="color: #888">
            <a href=".\About" title="Learn more about the Market">Read more…</a> | <a
                href=".\Vendors" title="See who sells what at the Market">Meet the Vendors</a>
            | <a href=".\Newsletter" title="Subscribe to our email newsletter">Email Newsletter</a>
            <span style="float: right"><a href="javascript:hideMission();">Dismiss</a></span>
        </p>
    </div>
    <% } %>
    <jfl:FeedContent ID="feedContent" Category="home" HandleSplit="true" ShowAge="true" 
        ShowAuthor="true" ShowHeadingAsLink="true" runat="server" />
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <jfl:ScheduledEvents ID="events" Url="http://www.google.com/calendar/ical/westernwakefarmersmarket.org_m0pmqcck35r6n8ag45vifsc4oo@group.calendar.google.com/public/basic.ics"
        runat="server" />
    <jfl:Donate ID="donate" runat="server" />
    <jfl:InSeason ID="inSeason" runat="server" />
    <!--
	<p>
		<img id="snapshot" runat="server" alt="North Carolina Produce" src="~/Images/assorted_veggies-2.jpg"
			style="width: 100%" /></p>
	-->
</asp:Content>
