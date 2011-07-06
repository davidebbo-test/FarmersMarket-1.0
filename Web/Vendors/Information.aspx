<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="FarmersMarket.Web.Vendors.Information"
    MasterPageFile="~/CurrentVersion.Master" Title="Becoming a Vendor for the Western Wake Farmers’ Market" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        p.deadline-passed { border-left: solid .5em #EF4035; padding-left: .75em; font-size: 125%; }
    </style>
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <p class="deadline-passed">The application deadline for the 2011 market season has officially closed.
        If you&rsquo;re still interested in becoming a vendor, please follow up with us
        later this year for the 2012 season.</p>
    <h1>
        Information for Interested Vendors</h1>
    <p>
        Thank you for your interest in becoming a vendor at the Western Wake Farmers' Market. We have adopted the following procedures to make the application process as fair and simple as possible.</p>
    <p>
        The Western Wake Farmers’ Market, Inc. is a corporation that contracts with the local vendors who sell their products at Western Wake Farmers’ Market located at 1226 Morrisville Carpenter Road , Cary, NC 27511. The market site is at Carpenter Village Marketplace, which is 4.4 miles west of Hwy 40 on Aviation Parkway/Morrisville Carpenter Road (Exit 285) OR 1.4 east of Hwy 55 on Morrisville Carpenter Road.</p>
    <ul>
        <li>The 2011 market season operates each Saturday from April 3 to November 20 from 8:00
            <small>AM</small> to 12:00 <small>PM</small>, rain or shine (9<small>AM</small> to 12<small>PM</small> from December-March).</li>
        <li>Vendors will be limited to qualified applicants who reside and produce their products within a 125-mile radius of the Market.</li>
    </ul>
    <p>
        The 2011 season fees are as follows:</p>
    <ul>
        <li>$25.00 non-refundable application fee. This fee should be submitted along with this Vendor Application.</li>
        <li>An advance payment of fees for the space(s) to be used at your first ten (10) market sale days. The fees are $10.00 per space per day. This payment of $100 is due after WWFM accepts you as a vendor for the 2011 season.</li>
        <li>All vendors are expected to attend at least 70% of market days. This does not apply to seasonal vendors.</li>
        <li>All prepared food items, meat, fish, and cheese sold must meet state and local health regulations including the inspection of the prepared foods seller's kitchens by the North Carolina Department of Agriculture health inspectors and labeling in compliance with regulations. Sellers of meat and fish must have valid licenses. Vendors must have a copy of licenses/certifications with them at market and on file with the market manager. Wild harvested products must adhere to all NC and federal laws.</li>
        <li>All vendors are strongly recommended to have general liability insurance.</li>
    </ul>
    <p>
        Prior to completing the application below, please read the
        <asp:HyperLink NavigateUrl="~/Vendors/Rules.aspx" runat="server">
        WWFM Market Rules</asp:HyperLink>.
    </p>
    <p style="font-size: large; font-weight: bold;">
        <asp:HyperLink ID="ApplyNowLink" runat="server" NavigateUrl="~/Vendors/Apply.aspx" ToolTip="On-line Vendor Application">Apply Now</asp:HyperLink></p>
    <p>
        Please fill out the application completely. Applications not filled out completely will not be considered. Your $25 non-refundable application fee may be submitted to WWFM via Paypal or may be mailed to:</p>
    <p>
        WWFM, Inc.<br />
        PO Box 1113<br />
        Morrisville, NC 27560</p>
    <p>
        We will accept applications received online by <strong>Monday, February 14, 2011</strong> so we are able to begin the approval process. You will receive an email or letter regarding acceptance or rejection of your application by March 7, 2011. Site visits, whether a new or previous vendor, may be required prior to determination. You will be contacted to schedule a site visit if needed. Each vendor must agree to a set of rules and contract obligations that govern the operation of the market.</p>
    <p>
        Please refer questions to Kim Hunter at kimconyer [at] gmail [dot com] or 919-349-4419.</p>
    <p>
        Or, use our
        <asp:HyperLink NavigateUrl="~/Contact/Default.aspx" runat="server">contact page</asp:HyperLink>
        to ask your question.</p>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <p>
        Before applying to become a vendor, please review the <a href="Rules.aspx">Market Rules</a>.</p>
</asp:Content>
