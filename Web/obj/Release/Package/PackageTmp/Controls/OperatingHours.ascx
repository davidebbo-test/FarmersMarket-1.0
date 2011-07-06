<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OperatingHours.ascx.cs"
    Inherits="FarmersMarket.Web.Controls.OperatingHours" %>
<%@ OutputCache Duration="3600" Shared="true" VaryByParam="*" %>
<h2>Open<br />Year-round</h2>
    <p><strong>Saturdays</strong><br />
    <%= MarketStartTime %> <small>AM</small> &ndash; 12 <small>PM</small></p>
<%
    if (DateTime.Today > new DateTime(2011, 4, 27))
    {
%>
    <p><strong>Tuesdays</strong><br />
    3:30 &ndash; 6:30 <small>PM</small></p>
<%        
    }
 %>
<hr />