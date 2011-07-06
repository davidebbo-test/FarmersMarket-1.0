<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Apply.aspx.cs" 
    Inherits="FarmersMarket.Web.Vendors.Apply"
    MaintainScrollPositionOnPostback="false" 
    MasterPageFile="~/CurrentVersion.Master"
    Title="Becoming a Vendor for the Western Wake Farmers’ Market" 
    EnableSessionState="false" 
    ValidateRequest="false" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .requiredField
        {
            background-color: #FFFFCC;
        }
        
        .selectedCategory
        {
            color: #00853E;
            font-weight: bold;
        }
        
        .questions
        {
            border-bottom: solid .2em #999;
            padding-bottom: 1em;
            margin-bottom: 1.5em;
        }
        
        table.marketDates
        {
            padding-bottom: 1em;
        }
    </style>
    <script language="javascript" type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.min.js"></script>
    <script type="text/javascript">
        // Define the entry point
        $(document).ready(function () {
            // The DOM (document object model) is constructed
            // We will initialize and run our plugin here
        });
    </script>
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>
        Vendor Application Form</h1>
    <p>
        Thank you for your interest in vendor at WWFM. Please review the
        <asp:HyperLink ID="vendorRulesLink" NavigateUrl="~/Vendors/Rules.aspx" runat="server">Rules of the Market</asp:HyperLink>
        before submitting your application. The deadline for 2011 season applications is
        Monday, February 14, 2011.
    </p>
    <p>
        Applicants will receive a response the week of February 21, 2011 or sooner.
    </p>
    <fieldset>
        <asp:MultiView ID="multiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="vendorInformationView" runat="server">
                <h3>
                    Vendor Information</h3>
                <p>
                    <asp:Label ID="nameLabel" AssociatedControlID="nameBox" runat="server">Farm or Business Name</asp:Label><br />
                    <asp:TextBox ID="nameBox" MaxLength="40" Width="50%" runat="server" AutoCompleteType="Company" />
                    <asp:RequiredFieldValidator runat="server" ID="requireName" CssClass="validationError"
                        EnableClientScript="true" ControlToValidate="nameBox" ErrorMessage="<br />Please provide a name"
                        Display="Dynamic" />
                </p>
                <p>
                    <asp:Label ID="ownerLabel" AssociatedControlID="nameBox" runat="server">Name(s) of Owner(s)</asp:Label><br />
                    <asp:TextBox ID="ownerBox" MaxLength="40" Width="50%" runat="server" AutoCompleteType="DisplayName" />
                    <asp:RequiredFieldValidator runat="server" ID="requiredOwner" CssClass="validationError"
                        EnableClientScript="true" ControlToValidate="ownerBox" ErrorMessage="<br />Please provide the owner(s)' names"
                        Display="Dynamic" />
                    </p>
                <p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
                    Vendors will be limited to qualified applicants who reside and produce their products
                    within a 125-mile radius of the Market.
                </p>
                <p>
                    <asp:Label ID="addressLabel" AssociatedControlID="addressBox" runat="server">Mailing Address</asp:Label><br />
                    <asp:TextBox ID="addressBox" MaxLength="40" Width="50%" runat="server" AutoCompleteType="BusinessStreetAddress" /></p>
                <table width="50%" cellspacing="0">
                    <tr>
                        <td style="width: 70%; padding-right: 10px">
                            <asp:Label ID="cityLabel" AssociatedControlID="cityBox" runat="server">City/Town</asp:Label><br />
                            <asp:TextBox ID="cityBox" MaxLength="40" Width="100%" runat="server" AutoCompleteType="BusinessCity" />
                        </td>
                        <td>
                            <asp:Label ID="zipLabel" AssociatedControlID="zipBox" runat="server">Zip Code</asp:Label><br />
                            <asp:TextBox ID="zipBox" MaxLength="10" Width="100%" runat="server" AutoCompleteType="BusinessZipCode" />
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:Label ID="siteLabel" AssociatedControlID="siteBox" runat="server">Web Site (optional)</asp:Label><br />
                    <asp:TextBox ID="siteBox" MaxLength="40" Width="50%" runat="server" AutoCompleteType="BusinessUrl" /><br />
                    <span class="sublabel">E.g. http://www.vendorname.com</span>
                    <asp:RegularExpressionValidator runat="server" ID="webSiteValidator" CssClass="validationError"
                        ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"
                        EnableClientScript="true" ControlToValidate="siteBox" ErrorMessage="<br />Please specify a valid web site address"
                        Display="Dynamic" />
                    </p>
                <p>
                    <asp:Label ID="emergencyLabel" AssociatedControlID="emergencyBox" runat="server">Contact in case of Emergency</asp:Label><br />
                    <asp:TextBox ID="emergencyBox" MaxLength="40" Width="50%" runat="server" /></p>
                <p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
                    If the goods you intend to sell are produced at a different location than the address
                    above, please specify it here.
                </p>
                <p>
                    <asp:Label ID="productionAddressLabel" AssociatedControlID="productionAddressBox"
                        runat="server">Production Address (if different from above)</asp:Label><br />
                    <asp:TextBox ID="productionAddressBox" MaxLength="40" Width="50%" runat="server" /></p>
                <table width="50%" cellspacing="0">
                    <tr>
                        <td style="width: 70%; padding-right: 10px">
                            <asp:Label ID="productionCityLabel" AssociatedControlID="productionCityBox" runat="server">City/Town</asp:Label><br />
                            <asp:TextBox ID="productionCityBox" MaxLength="40" Width="100%" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="productionZipLabel" AssociatedControlID="productionZipBox" runat="server">Zip Code</asp:Label><br />
                            <asp:TextBox ID="productionZipBox" MaxLength="10" Width="100%" runat="server" />
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:Label ID="extensionAgentLabel" AssociatedControlID="extensionAgentBox" runat="server">Extension Agent's Name (if applicable)</asp:Label><br />
                    <asp:TextBox ID="extensionAgentBox" MaxLength="40" Width="50%" runat="server" /></p>
                <p>
                    <asp:Label ID="businessStructureLabel" AssociatedControlID="businessStructureList"
                        runat="server">Business Structure</asp:Label><br />
                    <asp:DropDownList ID="businessStructureList" Width="50%" runat="server">
                        <asp:ListItem Value="NotSpecified">&nbsp;&mdash; Select one &mdash;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="Collaborative">Collaborative</asp:ListItem>
                        <asp:ListItem Value="Corporation">Corporation</asp:ListItem>
                        <asp:ListItem Value="LimitedLiabilityCorporation">Limted Liability Corporation (LLC)</asp:ListItem>
                        <asp:ListItem Value="Partnership">Partnership</asp:ListItem>
                        <asp:ListItem Value="SoleProprietorship">Sole Proprietorship</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="businessStructureRequired" runat="server" ControlToValidate="businessStructureList" 
                        InitialValue="NotSpecified" ErrorMessage="<br />Please specify your business structure" Display="Dynamic" />
                </p>
                <p>
                    <asp:Label ID="descriptionLabel" AssociatedControlID="descriptionBox" runat="server">Description</asp:Label><br />
                    <asp:TextBox ID="descriptionBox" TextMode="MultiLine" Rows="5" Width="90%" runat="server" /></p>
                <p>
                    <asp:Label ID="logoLabel" AssociatedControlID="logoUpload" runat="server">Upload Logo</asp:Label><br />
                    <asp:FileUpload ID="logoUpload" runat="server" Width="66%" /><br />
                    <span class="sublabel">Image files must be in JPG or PNG format</span>
                </p>
                <p>
                    If approved, may we include your company description on the market website?<br />
                    <asp:RadioButtonList ID="ShowOnWebSite" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
            </asp:View>
            <asp:View ID="productView" runat="server">
                <h3>
                    Products</h3>
                <p>
                    All prepared food items, meat, fish, and cheese sold must meet state and local health
                    regulations including the inspection of the prepared foods seller's kitchens by
                    the NC Dept of Agriculture health inspectors and labeling in compliance with regulations.
                    Sellers of meat and fish must have valid licenses. Vendors must have a copy of licenses
                    and/or certifications with them at market and on file with the market manager. Wild
                    harvested products must adhere to all NC and federal laws.
                </p>
                <!--
        <p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
        </p>
        -->
                <p>
                    <asp:Label ID="productsLabel" AssociatedControlID="vendorProducts" runat="server"><strong>What product(s) would you sell?</strong></asp:Label><br />
                    <asp:TextBox ID="vendorProducts" TextMode="MultiLine" Rows="4" Width="66%" runat="server" /><br />
                    <span class="sublabel">Please use a comma between products</span>
                </p>
                <p>
                    <strong>What <em>types</em> of products would you sell?</strong><br />
                    Please check all applicable categories from the list below. Additional questions,
                    based on your selections, will follow on subsequent pages.</p>
                <p>
                    <asp:CheckBoxList ID="productTypes" runat="server">
                        <asp:ListItem Value="Produce">Plants, Herbs, Vegetables, and Fruits</asp:ListItem>
                        <asp:ListItem Value="Protein">Protein or Dairy</asp:ListItem>
                        <asp:ListItem Value="Seafood">Seafood</asp:ListItem>
                        <asp:ListItem Value="Bakery">Baked Goods, James, etc., Crafts and Art</asp:ListItem>
                    </asp:CheckBoxList>
                </p>
                <p>
                    <asp:Label ID="practicingExperienceLabel" AssociatedControlID="practicingExperienceList"
                        runat="server">How long have you been farming/practicing your craft?</asp:Label><br />
                    <asp:DropDownList ID="practicingExperienceList" runat="server">
                        <asp:ListItem Text="&nbsp;&mdash; Select one &mdash;&nbsp;" Value="0" />
                        <asp:ListItem Text="Less than 1 year" Value="0" />
                        <asp:ListItem Text="1 year" Value="1" />
                        <asp:ListItem Text="2 years" Value="2" />
                        <asp:ListItem Text="3 years" Value="3" />
                        <asp:ListItem Text="4 years" Value="4" />
                        <asp:ListItem Text="5 years" Value="5" />
                        <asp:ListItem Text="6 years" Value="6" />
                        <asp:ListItem Text="7 years" Value="7" />
                        <asp:ListItem Text="8 years" Value="8" />
                        <asp:ListItem Text="9 years" Value="9" />
                        <asp:ListItem Text="10 years" Value="10" />
                        <asp:ListItem Text="More than 10 years" Value="11" />
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="sellingExperienceLabel" AssociatedControlID="sellingExperienceList"
                        runat="server">How long have your been selling these products?</asp:Label><br />
                    <asp:DropDownList ID="sellingExperienceList" runat="server">
                        <asp:ListItem Text="&nbsp;&mdash; Select one &mdash;&nbsp;" Value="0" />
                        <asp:ListItem Text="Less than 1 year" Value="0" />
                        <asp:ListItem Text="1 year" Value="1" />
                        <asp:ListItem Text="2 years" Value="2" />
                        <asp:ListItem Text="3 years" Value="3" />
                        <asp:ListItem Text="4 years" Value="4" />
                        <asp:ListItem Text="5 years" Value="5" />
                        <asp:ListItem Text="6 years" Value="6" />
                        <asp:ListItem Text="7 years" Value="7" />
                        <asp:ListItem Text="8 years" Value="8" />
                        <asp:ListItem Text="9 years" Value="9" />
                        <asp:ListItem Text="10 years" Value="10" />
                        <asp:ListItem Text="More than 10 years" Value="11" />
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="venuesLabel" AssociatedControlID="vendorVenues" runat="server">Where else have you sold them?</asp:Label><br />
                    <asp:TextBox ID="vendorVenues" TextMode="MultiLine" Rows="4" Width="66%" runat="server" /><br />
                    <span class="sublabel">Please use a comma between venues</span>
                </p>
            </asp:View>
            <asp:View ID="produceQuestionsView" runat="server">
                <h3>Plants, Herbs, Vegetables, and Fruits</h3>
                <p>
                    <asp:Label ID="produceAcresLabel" AssociatedControlID="produceAcres" runat="server">How many acres do you have in production?</asp:Label><br />
                    <asp:TextBox ID="produceAcres" Width="16%" runat="server" />
                    <asp:RegularExpressionValidator 
                        id="produceAcresValidator" runat="server" 
                        ErrorMessage="<br />Please provide the acreage rounded to the nearest acre" 
                        ValidationExpression="^\d+$" 
                        ControlToValidate="produceAcres">
                    </asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:Label ID="produceOwnedLabel" AssociatedControlID="produceOwned" runat="server">Do you own the land in production?</asp:Label><br />
                    <asp:RadioButtonList ID="produceOwned" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    <asp:Label ID="produceWeedsLabel" AssociatedControlID="produceWeeds" runat="server">How do you control weeds and pests?</asp:Label><br />
                    <asp:TextBox ID="produceWeeds" TextMode="MultiLine" Rows="4" runat="server" Width="66%" />
                </p>
                <p>
                    <asp:Label ID="produceFertilizerLabel" AssociatedControlID="produceFertilizer" runat="server">What type of fertilizer do you use?</asp:Label><br />
                    <asp:TextBox ID="produceFertilizer" runat="server" Width="66%" />
                </p>
                <p>
                    <asp:Label ID="produceGreenhouseLabel" AssociatedControlID="produceGreenhouse" runat="server">Do you use a greenhouse?</asp:Label><br />
                    <asp:RadioButtonList ID="produceGreenhouse" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    <asp:Label ID="produceCsaLabel" AssociatedControlID="produceCsa" runat="server">Do you offer a <abbr title="Community Supported Agriculture">CSA</abbr>?</asp:Label><br />
                    <asp:RadioButtonList ID="produceCsa" runat="server" RepeatLayout="Flow" AutoPostBack="true"
                        OnSelectedIndexChanged="OnSelectCsa">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <asp:Panel ID="produceCsaPanel" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="produceDropOffLabel" AssociatedControlID="produceDropOff" runat="server">Would WWFM be a drop-off location?</asp:Label><br />
                        <asp:RadioButtonList ID="produceDropOff" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </p>
                </asp:Panel>
            </asp:View>
            <asp:View ID="proteinQuestionsView" runat="server">
                <h3>Protein or Dairy</h3>
                <p>
                    <asp:Label ID="proteinAcresLabel" AssociatedControlID="proteinAcres" runat="server">How many acres do you have in production?</asp:Label><br />
                    <asp:TextBox ID="proteinAcres" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinOwnedLabel" AssociatedControlID="proteinOwned" runat="server">Do you own the land in production?</asp:Label><br />
                    <asp:RadioButtonList ID="proteinOwned" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    <asp:Label ID="proteinBreedsLabel" AssociatedControlID="proteinBreeds" runat="server">What types and breeds of animals do you raise?</asp:Label><br />
                    <asp:TextBox ID="proteinBreeds" TextMode="MultiLine" Rows="4" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinFeedingLabel" AssociatedControlID="proteinFeeding" runat="server">Describe your feeding practices for your animals:</asp:Label><br />
                    <asp:TextBox ID="proteinFeeding" TextMode="MultiLine" Rows="4" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinHousingLabel" AssociatedControlID="proteinHousing" runat="server">Describe the shelter for your animals:</asp:Label><br />
                    <asp:TextBox ID="proteinHousing" TextMode="MultiLine" Rows="4" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinHormonesLabel" AssociatedControlID="proteinHormones" runat="server">Describe any hormones and/or antibiotics used:</asp:Label><br />
                    <asp:TextBox ID="proteinHormones" TextMode="MultiLine" Rows="4" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinDiseaseLabel" AssociatedControlID="proteinDisease" runat="server">How do you deal with diseases and parasites?</asp:Label><br />
                    <asp:TextBox ID="proteinDisease" TextMode="MultiLine" Rows="4" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinPastureLabel" AssociatedControlID="proteinPasture" runat="server">When outdoors, do your animals have continuous access to grazeable pasture, fresh water, shade and shelter?</asp:Label><br />
                    <asp:RadioButtonList ID="proteinPasture" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    <asp:Label ID="proteinProcessorLabel" AssociatedControlID="proteinProcessor" runat="server">Who is your processor?</asp:Label><br />
                    <asp:TextBox ID="proteinProcessor" runat="server" Width="50%" />
                </p>
                <p>
                    <asp:Label ID="proteinSoilLabel" AssociatedControlID="proteinSoil" runat="server">Have you tested your soil for heavy metals or other contaminants?</asp:Label><br />
                    <asp:RadioButtonList ID="proteinSoil" runat="server" RepeatLayout="Flow">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
            </asp:View>
            <asp:View ID="seafoodQuestionsView" runat="server">
                <h3>Seafood</h3>
                <p>
                    <asp:Label ID="seafoodSourceLabel" AssociatedControlID="seafoodSource" runat="server">Source(s):</asp:Label><br />
                    <asp:TextBox ID="seafoodSource" Width="66%" runat="server" />
                </p>
                <p>
                    <asp:Label ID="seafoodDockLabel" AssociatedControlID="seafoodDock" runat="server">Dock location:</asp:Label><br />
                    <asp:TextBox ID="seafoodDock" Width="66%" runat="server" />
                </p>
                <p>
                    <asp:Label ID="seafoodBoatsLabel" AssociatedControlID="seafoodBoats" runat="server">Number and size of boats (please describe):</asp:Label><br />
                    <asp:TextBox ID="seafoodBoats" TextMode="MultiLine" Rows="4" Width="66%" runat="server" />
                </p>
                <p>
                    <asp:Label ID="seafoodInfoLabel" AssociatedControlID="seafoodInfo" runat="server">Please provide additional information regarding practices, processes, sourcing, etc.</asp:Label><br />
                    <asp:TextBox ID="seafoodInfo" TextMode="MultiLine" Rows="4" Width="66%" runat="server" />
                </p>
            </asp:View>
            <asp:View ID="bakeryQuestionsView" runat="server">
                <h3>Baked Goods, James, etc., Crafts and Art</h3>
                <p>
                    <asp:Label ID="bakeryMaterialsLabel" AssociatedControlID="bakeryMaterials" runat="server">What products and materials are used in producing your products?</asp:Label><br />
                    <asp:TextBox ID="bakeryMaterials" TextMode="MultiLine" Rows="4" Width="66%" runat="server" />
                </p>
                <p>
                    <asp:Label ID="bakeryIngredientsLabel" AssociatedControlID="bakeryIngredients" runat="server">Please list any local ingredients used in your products:</asp:Label><br />
                    <asp:TextBox ID="bakeryIngredients" TextMode="MultiLine" Rows="4" Width="66%" runat="server" />
                </p>
            </asp:View>
            <asp:View ID="organicView" runat="server">
                <p>
                    <asp:Label ID="organicLabel" AssociatedControlID="organic" runat="server">Are any of your products certified organic?</asp:Label><br />
                    <asp:RadioButtonList ID="organic" AutoPostBack="true" runat="server" RepeatLayout="Flow"
                        OnSelectedIndexChanged="OnClickOrganic">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <asp:Panel ID="organicProducts" Visible="false" runat="server">
                    <p>
                        Which of your products are certified organic?
                    </p>
                    <p>
                        <asp:CheckBoxList ID="organicProductList" runat="server" RepeatLayout="Flow">
                        </asp:CheckBoxList>
                    </p>
                </asp:Panel>
            </asp:View>
            <asp:View ID="logisticsView" runat="server">
                <h3>
                    Logistics</h3>
                <p>
                    <asp:Label ID="spacesLabel" AssociatedControlID="numberOfSpaces" runat="server">How many 10&times;10' spaces would you need?</asp:Label><br />
                    <asp:RadioButtonList ID="numberOfSpaces" RepeatLayout="Flow" runat="server">
                        <asp:ListItem Text="1" Value="1" Selected="True" />
                        <asp:ListItem Text="2" Value="2" />
                    </asp:RadioButtonList>
                </p>
                <!--
                <p style="float: right; margin-top: 1.25em; width: 45%; display: block;">
                    The market operates each Saturday from 8:00 <small>AM</small> to 12:00 <small>PM</small>.
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
                -->
                <asp:Table ID="marketCalendar" runat="server" CssClass="marketDates">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell ColumnSpan="6">Indicate which dates you wish to attend the market:</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <p>We will hold a mid-week market on Tuesday afternoons during the prime season (mid-May through August). Are you applying for:<br />
                    <asp:RadioButtonList CssClass="radioButtons" ID="marketDays" RepeatLayout="Flow" runat="server">
                        <asp:ListItem Text="Saturday only" Selected="True" Value="64" />
                        <asp:ListItem Text="Tuesday only" Value="4" />
                        <asp:ListItem Text="Both Saturday and Tuesday" Value="68" />
                    </asp:RadioButtonList>
                </p>
            </asp:View>
            <asp:View ID="followUpView" runat="server">
                <h3>
                    Follow up</h3>
                <p>
                    <asp:Label ID="contactLabel" AssociatedControlID="contactBox" runat="server">Who should we follow up with?</asp:Label><br />
                    <asp:TextBox ID="contactBox" MaxLength="40" Width="50%" runat="server" /></p>
                <p>
                    <asp:Label ID="phoneLabel" AssociatedControlID="phoneBox" runat="server">Phone #</asp:Label><br />
                    <asp:TextBox ID="phoneBox" MaxLength="14" runat="server" Width="50%" />
                    <asp:RegularExpressionValidator ID="phoneValidator" CssClass="validationError" runat="server"
                        EnableClientScript="true" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
                        ControlToValidate="phoneBox" ErrorMessage="<br />Please provide a valid phone number"
                        Display="Dynamic" />
                </p>
                <p>
                    <asp:Label ID="emailLabel" AssociatedControlID="emailBox" runat="server">Email</asp:Label><br />
                    <asp:TextBox ID="emailBox" MaxLength="40" Width="50%" runat="server" />
                    <asp:RegularExpressionValidator runat="server" ID="emailValidator" CssClass="validationError"
                        EnableClientScript="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="emailBox" ErrorMessage="<br />Please provide a valid email address"
                        Display="Dynamic" />
                    <br />
                    <span class="sublabel">We don&rsquo;t spam.</span></p>
                <p>
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Lf8ub8SAAAAAHuZlVp3-2mFekYsjS82ODNhBqo9"
                        PrivateKey="6Lf8ub8SAAAAAAwsqkbZ9iFonG1tdtaU3B0AR5Wz" />
                </p>
                <p>
                    I certify that the information on this application is true. If any of this information
                    is found to be untrue, I forfeit my right to sell that the WWFM, and any fees. By
                    selecting &ldquo;Submit Application,&rdquo; I agree to the
                    <asp:HyperLink NavigateUrl="~/Vendors/Rules.aspx" runat="server">Rules of the Market</asp:HyperLink>.</p>
                <p>
                    We expect to provide a respond to all applications by the week of February 21, 2011.</p>
                <p>
                    <asp:Button ID="submitButton" Text="Submit Application" CssClass="submit" OnClick="OnSubmit"
                        runat="server" /></p>
            </asp:View>
        </asp:MultiView>
        <asp:Button ID="backButton" Text="&lt; Back" OnClick="OnBack" Enabled="false" runat="server" />&nbsp;
        <asp:Button ID="nextButton" Text="Next &gt;" OnClick="OnNext" runat="server" />
    </fieldset>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <p style="margin: 0; padding: 0">
        Before applying to become a vendor, please review the
        <asp:HyperLink NavigateUrl="~/Vendors/Rules.aspx" Target="_blank" runat="server">Market Rules</asp:HyperLink>.</p>
</asp:Content>
