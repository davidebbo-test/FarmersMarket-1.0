<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="FarmersMarket.Web.Rules"
    MasterPageFile="~/CurrentVersion.Master" Title="Rules of the Western Wake Farmers’ Market" %>

<asp:Content ID="providedHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        form#aspnetForm ol li
        {
            padding-bottom: .66em;
        }
    </style>
</asp:Content>
<asp:Content ID="providedContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>
        Western Wake Farmers&rsquo; Market, Inc. Market Rules</h1>
    <p>
        <asp:HyperLink ID="linkPDF" NavigateUrl="~/Docs/WesternWakeFarmersMarket-MarketRules-2011.pdf"
            Text="Download these rules in PDF format" runat="server" /></p>
    <h2>
        Contents</h2>
    <ol>
        <li><a href="#eligible">Eligible Vendors and Products</a></li>
        <li><a href="#requirements">Vendor Requirements</a></li>
        <li><a href="#logistics">Space Allocation, Equipment &amp; Supplies</a></li>
        <li><a href="#mission">Mission</a></li>
    </ol>
    <p>
        The Western Wake Farmers Market will be open every Saturday from April through November
        2011 beginning at 8:00 <small>AM</small> and ending at 12:00 <small>PM</small>.</p>
    <p>
        Vendors at the Western Wake Farmers’ Market (&ldquo;the Market&rdquo;) agree to
        abide by these Market Rules. These Market Rules are subject to change and it is
        the obligation of each Vendor to ensure compliance with the Market Rules as amended.</p>
    <p>
        In accordance with the 2011 Vendor Agreement signed by all approved vendors, any
        violation of these Market Rules shall constitute a breach of the 2011 Vendor Agreement
        and shall be cause for the termination of that agreement in accordance with its
        terms.</p>
    <h2>
        <a name="eligible">Eligible Vendors and Products</a></h2>
    <p>
        Vendors in the Market operated by WWFM Inc. shall sell or vend products produced
        by the vendor. Vendors must reside and produce the items they sell within a one
        hundred twenty-five (125) mile radius of Wake County, NC.</p>
    <p>
        Products, which can be sold, include:</p>
    <ol style="list-style-type: lower-alpha">
        <li>Any vegetable grown by the Vendor from seeds, sets, or seedlings.</li>
        <li>Any fruits, nuts or berries grown by the Vendor from trees, bushes, or vines on
            the Vendor’s property (owned or leased).</li>
        <li>Any plant grown by the Vendor from seed, seedlings, transplants or cuttings.</li>
        <li>Bulbs propagated by the Vendor.</li>
        <li>Honey produced by the Vendor’s bees.</li>
        <li>Eggs produced from the Vendor’s hens.</li>
        <li>Cheese, or milk products made from the Vendor’s animals and produced on the Vendor’s
            property.</li>
        <li>Cut or dried flowers grown by the Vendor.</li>
        <li>Firewood cut by the Vendor from the Vendor’s property.</li>
        <li>Preserves, pickles, relishes, jams and jellies made by the Vendor.</li>
        <li>Straw baled by the Vendor.</li>
        <li>Baked goods made by the Vendor at the Vendor’s property.</li>
        <li>Meats from animals raised by the Vendor.</li>
        <li>Seafood that is locally caught using environmentally friendly fishing methods.</li>
        <li>Packaged Foods (wrapped and labeled for consumer purchase) approved by WWFM Inc.</li>
        <li>Beverages that may be sold include coffee, herbal teas, meade, and all natural lemonade
            (no artificial ingredients) and other beverages sold in paper cups as approved by
            WWFM Inc.</li>
        <li>Soaps and herbal care body products hand produced by the Vendor.</li>
        <li>Farm related crafts (bird feeders, dried flowers, photos, etc) approved by WWFM
            Inc.</li>
    </ol>
    <p>
        Products, which cannot be sold, include:</p>
    <ol style="list-style-type: lower-alpha">
        <li>Low acid canned foods (such as green beans, corn, carrots, etc.).</li>
        <li>Canned tomato products.</li>
        <li>Decorative pumpkins (edible pie pumpkins and pumpkin squash are permitted).</li>
        <li>Raw milk.</li>
        <li>Ready-to-Eat food (foods served to the consumer for immediate consumption).</li>
    </ol>
    <p>
        Except as specifically provided above, no food product may be sold at the Market
        without the consent of WWFM Inc.</p>
    <h2>
        <a name="requirements">Vendor Requirements</a></h2>
    <p>
        Vendors are also required to meet the following stipulations (WWFM, Inc assumes
        no responsibility regarding vendors and their certifications):</p>
    <p>
        All goods sold at the Market must comply with all applicable federal, state and
        local laws, including, without limitation, all applicable health regulations, as
        well as the N.C. Department of Agriculture’s general guidelines regarding products
        exhibited for sale at farmers’ markets and curb markets. To the extent any Vendor
        is selling any product that requires the Vendor to obtain and maintain any license
        or certification, the Vendor shall have and maintain such license or certification
        and shall make it available for immediate inspection by the Market Manager upon
        request.</p>
    <p>
        Additionally,</p>
    <ol style="list-style-type: lower-alpha">
        <li>All Vendors must grow their own produce. <em>No reselling is permitted</em>.</li>
        <li>WWFM Inc. reserves the right to inspect and re‐inspect any vendor’s farm/business
            location to verify a product’s origin, but WWFM Inc. has no obligation to do so.</li>
        <li>No water or ice that comes into contact with meat or fish may be deposited or allowed
            to drain onto the MARKET premises.</li>
        <li>Any Vendor using the term &ldquo;organic&rdquo; must meet the requirements of the
            National Organic Program and submit copy of the Vendor’s certification to the Market
            Manager.</li>
        <li>No live animals may be physically sold or given away at the Market.</li>
        <li>If a Vendor uses scales at the Market, the Vendor must have them approved by the
            NCDA (North Carolina Department of Agriculture).</li>
        <li>CRAFTS: Crafts must be produced on Vendor’s property and be approved by the Market
            Manager as furthering WWFM Inc.’s Mission, as set forth in Section 4. Whenever possible,
            craft items should be environmentally friendly and/or promote sustainable living.</li>
    </ol>
    <p>
        General Premise Requirements:</p>
    <ol style="list-style-type: lower-alpha">
        <li>Vendors may have access to their space(s) beginning one hour before the Market begins
            and must vacate and clean the premises by no later than 30 minutes after the Market
            ends.</li>
        <li>Except as expressly permitted by the Market Manager, all Vendors must be in their
            assigned space(s) by 7:45 <small>AM</small> on Saturdays at the Market.</li>
        <li>Spaces will be assigned by the Market Manager before the Market begins.</li>
        <li>For safety reasons, on Market days, early take-down and departure before closing
            time will not be allowed. Exceptions may be made in case of emergency at the discretion
            of Market Manager.</li>
        <li>Each Vendor must have a 2011 Vendor Agreement on file with WWFM Inc. and have fees
            paid up to date.</li>
        <li>Market Signage Guidelines:
            <ol style="list-style-type: lower-roman">
                <li>Prices must be clearly posted for all items sold.</li>
                <li>Only certified organic growers may use the term &ldquo;organic&rdquo; in their advertising
                    at the Market.</li>
            </ol>
        </li>
        <li>Vendors are required to set up their display each day they offer goods for sale
            at the Market. They are to be present and selling at their space(s) during the time
            their goods are offered for sale.</li>
        <li>Vendors may assign persons to assist them in selling his/her products if the representative
            is knowledgeable of the products and either a family member or employee of the Vendor.</li>
        <li>Vendors may not share their space with others without the expressed written consent
            of WWFM Inc.</li>
        <li>Any cooperative selling arrangements between Vendors (one Vendor selling another
            Vendor&rsquo;s products for him/her in the event that Vendor cannot be present)
            must be preapproved in writing by the Market Manager and/or WWFM Inc.</li>
        <li>Community Supported Agriculture (&ldquo;CSA&rdquo;): CSA&rsquo;s will be allowed
            only with approval from the Market Manager. All CSA Vendors must also be an approved
            Vendor at the Market; no CSA pick‐up only is allowed. All CSA items must be boxed
            separately.</li>
        <li>Vendors wishing to sell a new category of product to the market must have that product
            approved by the Market Manager prior to selling.</li>
    </ol>
    <p>
        Other Requirements:</p>
    <ol style="list-style-type: lower-alpha">
        <li>All Vendors must dress appropriately, including shoes and shirts and keep their
            hair tied back if serving food.</li>
        <li>Smoking by Vendors is NOT permitted in any spaces or in the Market area.</li>
        <li>No live animals are allowed in the Market space unless they are service animals
            for people with disabilities.</li>
        <li>All edible goods must be safe for human consumption.</li>
        <li>The Market Manager is authorized to require a Vendor to immediately remove any low
            quality merchandise, as determined by the Market Manager in its sole discretion,
            from the Market.</li>
        <li>Vendors are required to maintain their space(s) in a clean, safe, and sanitary manner,
            including protecting the pavement from oil or fuel drips from any part of the Vendor’s
            vehicle. This includes hauling away any trash or garbage that is generated in or
            around the booth and sweeping up any product debris left on the ground.</li>
        <li>If Vendor is using cups, toothpicks, etc. for sampling purposes, they must supply
            their booth with a small trash can or attach a small garbage bag to their booth
            for their customers.</li>
        <li>Vendors must bring their own brooms and dust pans if necessary for clean up.</li>
        <li>Vendors will park in spaces designated by the Market Manager before the Market begins.</li>
        <li>No marketing outside the designated spaces is permitted.</li>
    </ol>
    <h2>
        <a name="logistics">Space Allocation, Equipment &amp; Supplies</a></h2>
    <ol style="list-style-type: lower-alpha">
        <li>Each Vendor is responsible for bringing, setup and takedown of his/her own white
            10’x10’ canopy and table(s) to WWFM. Any other style canopy is subject to approval
            by the Market Manager/WWFM Inc.</li>
        <li>Vendors must maintain these canopies in good condition to the satisfaction of the
            Market Manager.</li>
        <li>Each Vendor at Market may supply a stand, counter or tables not to exceed the width
            of his or her space(s).</li>
        <li>The Market Manager will assign spaces at the start of the season.</li>
        <li>Vendors with less frequent usage such as seasonal vendors will be assigned available
            spaces upon arrival to the Market.</li>
    </ol>
    <h2>
        <a name="mission">Mission</a></h2>
    <p>
        The Mission of the Western Wake Farmer’s Market Inc. is for all people in our community
        to become educated about and benefit from locally grown food. Our aim is to help
        all walks of life, from the farmers to the local consumer to those less fortunate
        who might need assistance through the local food bank.</p>
    <p>
        Our focus is to educate consumers about locally produced and sustainable food. We
        will achieve this by offering a farmer’s market where consumers have direct access
        to locally grown produce. We will use the market day to provide a forum for consumers
        and their families to understand, appreciate, and learn about the interconnectedness
        of food and the environment.</p>
    <p>
        In addition to consumers gaining direct access to the farmers who grow their food,
        we will promote courses and conduct demonstrations that will educate the consumer
        on how to make healthy food and environmental choices. We will further this education
        by partnering with local agricultural, environmental, and green organizations. In
        addition, we will also facilitate the donation of farm food to people at risk of
        hunger.</p>
    <p>
        <em>Per the 2011 Vendor Agreement, Vendors must abide by these Market Rules to participate.
            Any complaints, disputes or violations of the rules shall be directed to the Market
            Manager or they can be submitted in writing to WWFM Inc. PO Box 1113, Morrisville,
            NC. Whenever possible, this should be handled before or after the market so as not
            to interrupt market activities.</em></p>
</asp:Content>
<asp:Content ID="pageSpecificContent" ContentPlaceHolderID="pageSpecific" runat="server">
    <p style="margin-top: 1em">
        <a href="Information.aspx">
            <img id="Img1" src="~/Images/new_vendor.png" style="border: 0; width: 213px" runat="server"
                alt="Become a vendor!" /></a>
    </p>
    <p>
        <a href="http://www.mayoclinic.com/health/organic-food/NU00255" title="Mayo Foundation for Medical Education and Research">
            Organic foods: Are they safer? More nutritious?</a></p>
</asp:Content>
