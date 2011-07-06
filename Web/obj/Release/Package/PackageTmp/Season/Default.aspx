<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Season"
    MasterPageFile="~/CurrentVersion.Master" Title="What’s in season at the Western Wake Farmers’ Market?" %>
<%@ OutputCache Duration="3600" Location="Any" VaryByParam="*" %>
<%@ Import Namespace="FarmersMarket.Web" %>
<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" media="screen">
        dt
        {
            padding-bottom: 1em;
        }
        thead tr th
        {
            font-weight: normal;
        }
        thead tr th.current
        {
            font-weight: bold;
        }
        tr td.unavailable
        {
            background-color: #EEE;
            border: solid 1px #999;
            text-align: center;
        }
        thead tr th
        {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>
        What&rsquo;s in Season?</h1>
    <p>
        This chart depicts the availability of various fruits and vegetables grown in North
        Carolina. Please note that this information is meant as a guide and we can&rsquo;t
        guarantee the availability of any of these items on any particular Saturday.
    </p>
    <asp:Repeater ID="SeasonalAvailability" runat="server">
        <HeaderTemplate>
            <table id="availability" style="width: 100%">
                <thead>
                    <tr>
                        <%# MakeHeader() %>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <%# MakeRow((Produce)Container.DataItem) %>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <jfl:InSeason ID="inSeason1" runat="server" />
    <!-- 
	<p style="margin-top: 1em">
		This coming Saturday falls in the month of <strong>
			<%=MarketDay.ToString("MMMM") %></strong>, during which the following items
		are generally in season:</p>
	<p>
		<asp:Literal ID="InSeason" runat="server" />
    </p>
    -->
    <jfl:Donate ID="donate" runat="server" />
</asp:Content>
