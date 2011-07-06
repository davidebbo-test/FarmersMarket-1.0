<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Directions.ascx.cs"
    Inherits="FarmersMarket.Web.Controls.Directions" %>
<%@ OutputCache Duration="3600" Shared="true" VaryByParam="*" %>
<p>
    Located on Morrisville Carpenter Rd. between Davis Dr. and Hwy. 55 in Carpenter
    Village</p>
<div class="adr" style="display:none">
    <div class="street-address">
        1226 Morrisville Carpenter Rd.</div>
    <span class="locality">Cary</span>, <span class="region">NC</span> <span class="postal-code">
        27519</span>
    <div class="country-name">
        U.S.A.</div>
</div>
<p style="margin-bottom: 2em">
    <asp:HyperLink ID="linkDirections" runat="server">
		Get directions</asp:HyperLink></p>
