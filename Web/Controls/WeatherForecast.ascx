<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeatherForecast.ascx.cs"
    Inherits="FarmersMarket.Web.Controls.WeatherForecast" %>
<table class="weather" runat="server">
    <thead>
        <tr>
            <th colspan="2">
                Expected weather for this Saturday's Market
            </th>
        </tr>
    </thead>
    <tr>
        <td>
            <asp:HyperLink ID="moreInfoLink" runat="server">
                <asp:Image ID="forecastIcon" runat="server" />
            </asp:HyperLink>
        </td>
        <td class="temperatures">
            <% if (Data.TemperatureLow > 0)
               { %>
            <span class="high">
                <%=Data.TemperatureHigh %>&deg;</span><span class="low">
                    <%= String.Format("{0}&deg;", Data.TemperatureLow) %></span>
            <% }
               else
               { %>
            <span class="highonly">
                <%=Data.TemperatureHigh %>&deg;</span>
            <% } %>
        </td>
    </tr>
    <tfoot>
        <tr>
            <td id="Advisory" colspan="2" style="padding-top: .75em; display: none" runat="server">
                Open rain or shine
            </td>
        </tr>
    </tfoot>
</table>
