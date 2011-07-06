<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduledEvents.ascx.cs"
    Inherits="FarmersMarket.Web.Controls.ScheduledEvents" %>

<div style="text-align: left" class="bottomBorder">
    <h2>
        Upcoming Events</h2>
        <%=GetCalendarEvents() %>
<p>
    <a href="<%= Url %>" title="Subscribe to Upcoming Farmers' Market Events">Subscribe</a>
    (iCal)</p>
