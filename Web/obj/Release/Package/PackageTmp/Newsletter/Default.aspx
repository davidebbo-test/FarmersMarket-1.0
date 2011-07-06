<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmersMarket.Web.Newsletter.Default"
    MasterPageFile="~/CurrentVersion.Master" Title="Subscribe to the Western Wake Farmers’ Market Newsletter" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <meta id="MetaRefresh" runat="server" />
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>
        Subscribe to our Newsletter</h1>
    <asp:Panel ID="NewsletterSignup" runat="server" DefaultButton="SubscribeButton">
        <p>
            Sign up to receive our newsletter, <em>Western Wake Eats</em>, by email. It&rsquo;s
            generally sent out weekly (sometimes more often, sometimes less) and includes tips
            and details on what&rsquo;s planned for the Market. Your privacy is important to
            us; therefore, we will not sell, rent, or give your name or address to anyone.</p>
        <fieldset>
            <legend style="display: none">Your Information</legend>
            <p style="float: left; margin-right: 1em">
                <asp:Label ID="FirstNameLabel" AssociatedControlID="FirstNameText" Text="First name:"
                    runat="server" /><br />
                <asp:TextBox ID="FirstNameText" AutoCompleteType="FirstName" MaxLength="50" Width="10em"
                    runat="server" /><br />
                <asp:RequiredFieldValidator ControlToValidate="FirstNameText" Display="Dynamic" ErrorMessage="Please enter your first name<br />"
                    ID="FirstNameValidator" runat="server" />
            </p>
            <p style="float: left">
                <asp:Label ID="LastNameLabel" AssociatedControlID="LastNameText" Text="Last name:"
                    runat="server" /><br />
                <asp:TextBox ID="LastNameText" AutoCompleteType="LastName" MaxLength="50" Width="10em"
                    runat="server" /><br />
                <asp:RequiredFieldValidator ControlToValidate="LastNameText" Display="Dynamic" ErrorMessage="Please enter your last name<br />"
                    ID="LastNameValidator" runat="server" />
            </p>
            <p style="clear: both">
                <asp:Label ID="EmailAddressLabel" AssociatedControlID="EmailAddressText" Text="Email:"
                    runat="server" /><br />
                <asp:TextBox ID="EmailAddressText" AutoCompleteType="Email" MaxLength="80" Width="21.5em"
                    runat="server" /><br />
                <asp:RequiredFieldValidator ControlToValidate="EmailAddressText" Display="Dynamic"
                    ErrorMessage="Please enter a valid email address<br />" ID="EmailRequiredValidator"
                    runat="server" />
                <asp:RegularExpressionValidator ID="EmailAddressValidator" runat="server" ErrorMessage="Please enter a valid email address<br />"
                    ControlToValidate="EmailAddressText" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    Display="Dynamic" />
                <span class="sublabel">We don&rsquo;t spam &ndash; ever</span>
            </p>
            <p>
                <asp:Button ID="SubscribeButton" Text="Subscribe" CssClass="submit" runat="server"
                    CausesValidation="true" UseSubmitBehavior="true" />
                <span id="WorkingMessage" style="display: none">Recording your subscription&hellip;</span>
            </p>
        </fieldset>
        <hr style="margin-top: 2em" />
        <p>
            Western Wake Farmers' Market uses SafeUnsubscribe&reg; which guarantees the permanent
            removal of your email address from its mailing lists. Note: In each email you receive,
            there will be a link to unsubscribe or change areas of interest. Your privacy is
            important to us &mdash; please read our <a href="http://ui.constantcontact.com/roving/CCPrivacyPolicy.jsp">Email Privacy Policy</a>.</p>
    </asp:Panel>
    <asp:Panel ID="ResultPanel" Visible="false" runat="server">
        <asp:Literal ID="ResultHtml" runat="server" Mode="PassThrough" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <jfl:Mission ID="mission" runat="server" />
    <jfl:Donate ID="donate" runat="server" />
</asp:Content>
