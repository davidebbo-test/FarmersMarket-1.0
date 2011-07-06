<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Contact"
	MasterPageFile="~/CurrentVersion.Master" Title="Contact the Western Wake Farmers’ Market" ValidateRequest="false" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<h1 id="heading" runat="server">
		Contact Us</h1>
	<asp:Panel ID="contactForm" DefaultButton="submitButton" runat="server">
		<p>
			Please enter your message in the space below. Be sure to provide your email address
			if you&rsquo;d like us to get back to you.</p>
		<p>
			If you&rsquo;re interested in becoming a vendor, please review the
			<asp:HyperLink ID="vendorInfoLink" NavigateUrl="~/Vendors/Information.aspx" runat="server">Information for Interested Vendors</asp:HyperLink>.</p>
		<fieldset id="fieldSet" style="margin-top: 1.5em" runat="server">
			<p>
			    <asp:Label ID="messageLabel" AssociatedControlID="messageText" AccessKey="Q" runat="server">
					Question or comment</asp:Label><br />
				<asp:TextBox ID="messageText" TextMode="MultiLine" Rows="10" Width="35em" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="requireMessage" CssClass="validationError"
                    EnableClientScript="true" ControlToValidate="messageText" 
                    ErrorMessage="<br />What did you want to say?" Display="Dynamic" />
                </p>
			<p>
			    <asp:Label ID="nameLabel" AssociatedControlID="nameText" AccessKey="N" runat="server">
				    Your name (so we know what to call you)</asp:Label><br />
				<asp:TextBox ID="nameText" MaxLength="50" TextMode="SingleLine" Width="20em" CssClass="email"
					runat="server" /></p>
			<p>
			    <asp:Label ID="emailLabel" AssociatedControlID="emailText" AccessKey="E" runat="server">
					Email address (so we can get back to you)</asp:Label><br />
				<asp:TextBox ID="emailText" MaxLength="80" TextMode="SingleLine" Width="20em" CssClass="email"
					runat="server" /><br />

            <asp:RegularExpressionValidator ID="EmailAddressValidator" runat="server" ErrorMessage="Please enter a valid email address"
                ControlToValidate="emailText" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                Display="Dynamic" Width="40" /><br />
                <span class="sublabel">We don&rsquo;t spam &ndash; ever</span></p>
            <p>
                <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Lf8ub8SAAAAAHuZlVp3-2mFekYsjS82ODNhBqo9"
                    PrivateKey="6Lf8ub8SAAAAAAwsqkbZ9iFonG1tdtaU3B0AR5Wz" /></p>
			<p>
				<asp:Button ID="submitButton" Text="Send" CssClass="submit" OnClick="SendEmail" runat="server" /></p>
		</fieldset>
	</asp:Panel>
	<asp:Panel ID="ackPanel" Visible="false" runat="server">
		<p>
			<%=this.Outcome %></p>
	</asp:Panel>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
	<!-- <jfl:Directions ID="directions" runat="server" /> -->
	<jfl:Mission runat="server" />
	<jfl:Donate ID="donate" runat="server" />
</asp:Content>
