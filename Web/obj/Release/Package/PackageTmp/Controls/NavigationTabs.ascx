<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationTabs.ascx.cs"
	Inherits="FarmersMarket.Web.Controls.NavigationTabs" %>
<div style="margin: 0;">
	<!--
	<img id="imgTitle" runat="server" style="width:688px; height: 76px" alt="Western Wake Farmers' Market" src="~/Images/title-8.png" />
	-->
	<img id="imgLogo" runat="server" style="width:300px" alt="Western Wake Farmers' Market" src="~/Images/WWFM_Logo_Tagline_Color_RGB_Shadow.png" />
</div>
<ul>
	<li><asp:HyperLink ID="homeTab" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>
	<li><asp:HyperLink ID="seasonTab" runat="server" NavigateUrl="~/Season">In Season</asp:HyperLink></li>
	<li><asp:HyperLink ID="vendorsTab" runat="server" NavigateUrl="~/Vendors">Vendors</asp:HyperLink>
	<!--
		javascript:document.getElementById('vendors').style.display='block'; return false;
		<div id="vendors" style="display:block; margin: 10px 0 0 2px; padding: 1.25em 1.5em; top: 1.3em; left: 15px; position: absolute; width: 27em; z-index:10; background-color: White; border: solid 1px #999;">
			<dl style="padding: 0; margin: 0">
			<dt>Farms</dt>
			<dd>List of some farms<br />
			Farm #2<br />
			Farm #3</dd>
			</dl>
		</div>
	-->
	</li>
	<li><asp:HyperLink ID="sponsorsTab" runat="server" NavigateUrl="~/Sponsors">Sponsors</asp:HyperLink></li>
	<li><asp:HyperLink ID="recipeTab" runat="server" NavigateUrl="~/Recipes">Recipes</asp:HyperLink></li>
	<li><asp:HyperLink ID="aboutTab" runat="server" NavigateUrl="~/About">About</asp:HyperLink></li>
	<li><asp:HyperLink ID="contactTab" runat="server" NavigateUrl="~/Contact">Contact</asp:HyperLink></li>
	<li><asp:HyperLink ID="newsletterTab" runat="server" NavigateUrl="~/Newsletter">Newsletter</asp:HyperLink></li>
</ul>
