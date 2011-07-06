<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="FarmersMarket.Web.Vendors.Festival"
	MasterPageFile="~/CurrentVersion.Master" Title="Vendor Application for the Fall Craft Festival" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<h1>
		Western Wake Farmers&rsquo; Market Fall Craft Festival Vendor Application</h1>
	<p>
		For consideration to vend at the Western Wake Farmers&rsquo; Market Fall Craft Festival on 
		November 7, 2009, please provide the following information.</p>
	<fieldset>
		<h3>
			Vendor Information</h3>
		<p>
			<asp:Label ID="nameLabel" AssociatedControlID="nameBox" runat="server">Name of business or proprietor</asp:Label><br />
			<asp:TextBox ID="nameBox" MaxLength="40" Width="50%" runat="server" /></p>
		<p>
			<asp:Label ID="descriptionLabel" AssociatedControlID="descriptionBox" runat="server">Description</asp:Label><br />
			<asp:TextBox ID="descriptionBox" TextMode="MultiLine" Rows="5" Width="90%" runat="server" /></p>
		<p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
			Vendors will be limited to qualified applicants who reside and produce their products
			within a 125-mile radius of the Market.
		</p>
		<p>
			<asp:Label ID="addressLabel1" AssociatedControlID="addressBox1" runat="server">Address</asp:Label><br />
			<asp:TextBox ID="addressBox1" MaxLength="40" Width="50%" runat="server" /></p>
		<p>
			<asp:Label ID="cityLabel" AssociatedControlID="cityBox" runat="server">City/Town</asp:Label><br />
			<asp:TextBox ID="cityBox" MaxLength="40" Width="50%" runat="server" /></p>
		<p>
			<asp:Label ID="siteLabel" AssociatedControlID="siteBox" runat="server">Web site (optional)</asp:Label><br />
			<asp:TextBox ID="siteBox" MaxLength="40" Width="50%" runat="server" /><br />
			<span class="sublabel">E.g. www.vendorname.com</span></p>
		<h3>
			Products</h3>
		<p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
			All prepared food items, meat, fish, and cheese sold must meet state and local health
			regulations including the inspection of the prepared foods seller's kitchens by
			the NC Dept of Agriculture health inspectors and labeling in compliance with regulations.
			Sellers of meat and fish must have valid licenses. Vendors must have a copy of licenses/certifications
			with them at market and on file with the market manager. Wild harvested products
			must adhere to all NC and federal laws.
		</p>
		<p>
			<asp:Label ID="productsLabel" AssociatedControlID="vendorProducts" runat="server">What product(s) would you sell?</asp:Label><br />
			<asp:TextBox ID="vendorProducts" TextMode="MultiLine" Rows="4" Width="50%" runat="server" /><br />
			<span class="sublabel">Please use a comma between products</span>
		</p>
		<p>
			<asp:Label ID="durationLabel" AssociatedControlID="vendorDuration" runat="server">How long have you been selling them?</asp:Label><br />
			<asp:DropDownList ID="vendorDuration" runat="server">
				<asp:ListItem Text="&nbsp;&mdash; Select one &mdash;&nbsp;" />
				<asp:ListItem Text="Less than 1 year" />
				<asp:ListItem Text="1 year" />
				<asp:ListItem Text="2 years" />
				<asp:ListItem Text="3 years" />
				<asp:ListItem Text="4 years" />
				<asp:ListItem Text="5 years" />
				<asp:ListItem Text="More than 5 years" />
			</asp:DropDownList>
		</p>
		<p>
			<asp:Label ID="venuesLabel" AssociatedControlID="vendorVenues" runat="server">Where else have you sold them?</asp:Label><br />
			<asp:TextBox ID="vendorVenues" TextMode="MultiLine" Rows="3" Width="50%" runat="server" />
		</p>
		<h3>
			Logistics</h3>
		<p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
			The market operates each Saturday from April to November in 2009 from 8:00 <small>AM</small>
			to 12:00 <small>PM</small>.
		</p>
		<p>
			<asp:Label ID="freqLabel" AssociatedControlID="vendorFreq" runat="server">How often would you sell at the market?</asp:Label><br />
			<asp:RadioButtonList CssClass="radioButtons" ID="vendorFreq" RepeatLayout="Flow"
				runat="server">
				<asp:ListItem Text="Every Saturday" Selected="True" />
				<asp:ListItem Text="Every other Saturday" />
				<asp:ListItem Text="Once a month" />
			</asp:RadioButtonList>
		</p>
		<p>
			<asp:Label ID="spacesLabel" AssociatedControlID="numberOfSpaces" runat="server">How many 10&times;10' spaces would you need?</asp:Label><br />
			<asp:RadioButtonList ID="numberOfSpaces" RepeatLayout="Flow" runat="server">
				<asp:ListItem Text="1" Value="1" Selected="True" />
				<asp:ListItem Text="2" Value="2" />
			</asp:RadioButtonList>
		</p>
		<h3>
			Follow up</h3>
		<p>
			<asp:Label ID="contactLabel" AssociatedControlID="contactBox" runat="server">Who should we follow up with?</asp:Label><br />
			<asp:TextBox ID="contactBox" MaxLength="40" Width="50%" runat="server" /></p>
		<p>
			<asp:Label ID="phoneLabel" AssociatedControlID="areaCodeBox" runat="server">Phone #</asp:Label><br />
			<asp:TextBox ID="areaCodeBox" MaxLength="3" Width="3em" runat="server" />
			&ndash;
			<asp:TextBox ID="prefixBox" MaxLength="3" Width="3em" runat="server" />
			&ndash;
			<asp:TextBox ID="phoneBox" MaxLength="4" Width="4em" runat="server" /></p>
		<p>
			<asp:Label ID="emailLabel" AssociatedControlID="emailBox" runat="server">Email</asp:Label><br />
			<asp:TextBox ID="emailBox" MaxLength="40" Width="50%" runat="server" /><br />
			<span class="sublabel">We don&rsquo;t spam.</span></p>
		<p>
			By selecting &ldquo;Submit Application,&rdquo; I agree to the
			<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Vendors/Rules.aspx" runat="server">Rules of the Market</asp:HyperLink>.</p>
		<p>
			<asp:Button ID="submitButton" Text="Submit Application" CssClass="submit" runat="server" /></p>
	</fieldset>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<p style="margin: 0; padding: 0">
		Before applying to become a vendor, please review the <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Vendors/Rules.aspx" runat="server">Market Rules</asp:HyperLink>.</p>
</asp:Content>
