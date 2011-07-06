using System.Xml.Serialization;

namespace FarmersMarket.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    #region Enumerations

    [Serializable]
    public enum BusinessStructure
    {
        NotSpecified,
        Collaborative,
        Corporation,
        LimitedLiabilityCorporation,
        Partnership,
        SoleProprietorship,
        Other
    }

    [Flags]
    public enum MarketDaysOfWeek
    {
        None = 0x00,
        Sunday = 0x01,
        Monday = 0x02,
        Tuesday = 0x04,
        Wednesday = 0x08,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40,
    }

    [Flags]
    public enum ProductTypes
    {
        Other = 0x00,
        Produce = 0x01,
        Protein = 0x02,
        Seafood = 0x04,
        Bakery = 0x08
    }

    #endregion Enumerations

    [Serializable]
    public class BakeryQuestions
    {
        #region Properties

        public String LocalIngredients
        {
            get; set;
        }

        public String MaterialsUsed
        {
            get; set;
        }

        #endregion Properties
    }

    [Serializable]
    public class PhysicalAddress
    {
        #region Properties

        public String Address
        {
            get; set;
        }

        public String City
        {
            get; set;
        }

        public String State
        {
            get; set;
        }

        public String ZipCode
        {
            get; set;
        }

        #endregion Properties
    }

    [Serializable]
    public class ProduceQuestions
    {
        #region Properties

        public Int32 AcresInProduction
        {
            get; set;
        }

        public Boolean CsaDropOff
        {
            get; set;
        }

        public String FertilizerType
        {
            get; set;
        }

        public Boolean Greenhouse
        {
            get; set;
        }

        public Boolean OfferCsa
        {
            get; set;
        }

        public Boolean OwnLand
        {
            get; set;
        }

        public String PestControl
        {
            get; set;
        }

        #endregion Properties
    }

    [Serializable]
    public class ProteinQuestions
    {
        #region Properties

        public Int32 AcresInProduction
        {
            get; set;
        }

        public String AnimalBreeds
        {
            get; set;
        }

        public String AnimalShelter
        {
            get; set;
        }

        public String DiseasesAndParasites
        {
            get; set;
        }

        public String FeedingPractices
        {
            get; set;
        }

        public String HormonesAntiBiotics
        {
            get; set;
        }

        public Boolean OwnLand
        {
            get; set;
        }

        public Boolean PastureWaterShadAndShelter
        {
            get; set;
        }

        public String Processor
        {
            get; set;
        }

        public Boolean SoilTested
        {
            get; set;
        }

        #endregion Properties
    }

    [Serializable]
    public class SeafoodQuestions
    {
        #region Properties

        public String AdditionalInfo
        {
            get; set;
        }

        public String Boats
        {
            get; set;
        }

        public String DockLocation
        {
            get; set;
        }

        public String Source
        {
            get; set;
        }

        #endregion Properties
    }

    [Serializable]
    public class VendorApplication : IComparable
    {
        public VendorApplication()
        {
            BusinessStructure = BusinessStructure.NotSpecified;
            IncludeListingOnWebSite = true;
        }

        #region Fields

        private BakeryQuestions _bakeryQuestions;
        private PhysicalAddress _mailingAddress;
        private List<DateTime> _marketDates;
        private List<String> _organicProducts;
        private ProduceQuestions _produceQuestions;
        private PhysicalAddress _productionAddress;
        private List<String> _products;
        private ProteinQuestions _proteinQuestions;
        private SeafoodQuestions _seafoodQuestions;
        private List<String> _venues;

        #endregion Fields

        #region Properties

        public BakeryQuestions BakeryQuestions
        {
            get { return _bakeryQuestions ?? (_bakeryQuestions = new BakeryQuestions()); }
            set { _bakeryQuestions = value; }
        }

        public BusinessStructure BusinessStructure
        {
            get; set;
        }

        public String ContactEmail
        {
            get; set;
        }

        public String ContactName
        {
            get; set;
        }

        public String ContactPhone
        {
            get; set;
        }

        public String Description
        {
            get; set;
        }

        public String EmergencyContact
        {
            get; set;
        }

        public String ExtensionAgent
        {
            get; set;
        }

        public Boolean IncludeListingOnWebSite
        {
            get; set;
        }

        public String LogoImagePath { get; set; }

        public PhysicalAddress MailingAddress
        {
            get { return _mailingAddress ?? (_mailingAddress = new PhysicalAddress()); }
            set { _mailingAddress = value; }
        }

        public List<DateTime> MarketDates
        {
            get { return _marketDates ?? (_marketDates = new List<DateTime>()); }
            set { _marketDates = value; }
        }

        public MarketDaysOfWeek MarketDays { get; set; }

        public String Name
        {
            get; set;
        }

        public Int32 NumberOfSpaces
        {
            get; set;
        }

        public List<String> OrganicProducts
        {
            get { return _organicProducts ?? (_organicProducts = new List<String>()); }
            set { _organicProducts = value; }
        }

        public String Owner
        {
            get; set;
        }

        public ProduceQuestions ProduceQuestions
        {
            get { return _produceQuestions ?? (_produceQuestions = new ProduceQuestions()); }
            set { _produceQuestions = value; }
        }

        public PhysicalAddress ProductionAddress
        {
            get { return _productionAddress ?? (_productionAddress = new PhysicalAddress()); }
            set { _productionAddress = value; }
        }

        public List<String> Products
        {
            get { return _products ?? (_products = new List<String>()); }
            set { _products = value; }
        }

        public ProductTypes ProductTypes
        {
            get; set;
        }

        public ProteinQuestions ProteinQuestions
        {
            get { return _proteinQuestions ?? (_proteinQuestions = new ProteinQuestions()); }
            set { _proteinQuestions = value; }
        }

        public SeafoodQuestions SeafoodQuestions
        {
            get { return _seafoodQuestions ?? (_seafoodQuestions = new SeafoodQuestions()); }
            set { _seafoodQuestions = value; }
        }

        public List<String> Venues
        {
            get { return _venues ?? (_venues = new List<String>()); }
            set { _venues = value; }
        }

        [XmlIgnore]
        public Uri WebSite
        {
            get; set;
        }

        [XmlElement("WebSiteUri")]
        public String WebSiteUri
        {
            get
            {
                return (WebSite != null) ? WebSite.ToString() : String.Empty;
            }
            set {
                WebSite = !String.IsNullOrEmpty(value) ? new Uri(value) : null;
            }
        }

        public Int32 YearsPracticing
        {
            get; set;
        }

        public Int32 YearsSelling
        {
            get; set;
        }

        public String ToHtml()
        {
            var builder = new StringBuilder();

            builder.AppendLine("<html><body style=\"font-family: \"Segoe UI\" , Verdana, Arial, Helv; font-size: 83%;\">");
            builder.AppendLine("<p>Please submit a $25 non-refundable application fee via <a href=\"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3925033\">PayPal</a> to complete your application. Applications received without fee will not be reviewed.</p>");

            builder.AppendLine("<h3>Vendor Information</h3><dl>");
            builder.AppendFormat("<dt>Farm or Business Name</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(Name));
            builder.AppendFormat("<dt>Name(s) of Owner(s)</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(Owner));

            builder.AppendFormat("<dt>Mailing Address</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(
                String.Format("{0}{4}{1}, {2} {3}", 
                    MailingAddress.Address, 
                    MailingAddress.City, 
                    MailingAddress.State, 
                    MailingAddress.ZipCode, 
                    Environment.NewLine)));

            if (WebSite != null)
            {
                builder.AppendFormat("<dt>Web Site</dt><dd>{0}</dd>",
                                     HttpContext.Current.Server.HtmlEncode(WebSite.ToString()));
            }

            builder.AppendFormat("<dt>Contact in case of Emergency</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(EmergencyContact));

            if (!String.IsNullOrEmpty(ProductionAddress.Address))
            {
                builder.AppendFormat("<dt>Production Address</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(
                    String.Format("{0}{4}{1}, {2} {3}",
                        ProductionAddress.Address,
                        ProductionAddress.City,
                        ProductionAddress.State,
                        ProductionAddress.ZipCode,
                        Environment.NewLine)));
            }

            if (!String.IsNullOrEmpty(ExtensionAgent))
            {
                builder.AppendFormat("<dt>Extension Agent's Name</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(ExtensionAgent));
            }
            
            builder.AppendFormat("<dt>Business Structure</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(
                Enum.GetName(typeof(BusinessStructure), BusinessStructure)));

            builder.AppendFormat("<dt>Description</dt><dd>{0}</dd>", HttpContext.Current.Server.HtmlEncode(Description));
            builder.AppendFormat("<dt>May we include your company description on the market website?</dt><dd>{0}</dd>", 
                IncludeListingOnWebSite ? "Yes" : "No");

            builder.AppendFormat("</dl><h3>Products</h3><dl>");

            if (Products.Count > 0)
            { 
                builder.AppendFormat("<dt>What product(s) would you sell?</dt><dd>{0}</dd>", 
                    HttpContext.Current.Server.HtmlEncode(String.Join(", ", Products.ToArray())));

                if (OrganicProducts.Count > 0)
                {
                    builder.AppendFormat("<dt>Which of those product(s) are certified organic?</dt><dd>{0}</dd>",
                        HttpContext.Current.Server.HtmlEncode(String.Join(", ", OrganicProducts.ToArray())));
                }
            }

            builder.AppendFormat("<dt>How many years have you been farming/practicing your craft?</dt><dd>{0}</dd>", 
                Convert.ToString(YearsPracticing));

            builder.AppendFormat("<dt>How many years have your been selling these products?</dt><dd>{0}</dd>", 
                Convert.ToString(YearsSelling));

            builder.AppendFormat("<dt>Where else have you sold them?</dt><dd>{0}</dd>",
                HttpContext.Current.Server.HtmlEncode(String.Join(", ", Venues.ToArray())));

            builder.AppendLine("</dl>");

            if (ProductTypes.HasFlag(ProductTypes.Produce))
            {
                builder.AppendLine("<h3>Produce Question Responses</h3><dl>");
                builder.AppendFormat("<dt>How many acres do you have in production?</dt><dd>{0}</dd>", 
                    Convert.ToString(ProduceQuestions.AcresInProduction));
                builder.AppendFormat("<dt>Do you own the land in production?</dt><dd>{0}</dd>", 
                    ProduceQuestions.OwnLand ? "Yes" : "No");
                builder.AppendFormat("<dt>How do you control weeds and pests?</dt><dd>{0}</dd>", 
                    HttpContext.Current.Server.HtmlEncode(ProduceQuestions.PestControl));
                builder.AppendFormat("<dt>What type of fertilizer do you use?</dt><dd>{0}</dd>", 
                    HttpContext.Current.Server.HtmlEncode(ProduceQuestions.FertilizerType));
                builder.AppendFormat("<dt>Do you use a greenhouse?</dt><dd>{0}</dd>", 
                    ProduceQuestions.Greenhouse ? "Yes" : "No");
                builder.AppendFormat("<dt>Do you offer a CSA?</dt><dd>{0}</dd>", 
                    ProduceQuestions.OfferCsa ? "Yes" : "No");

                if (ProduceQuestions.OfferCsa)
                {
                    builder.AppendFormat("<dt>Would WWFM be a drop-off location?</dt><dd>{0}</dd>",
                        ProduceQuestions.CsaDropOff ? "Yes" : "No");
                }

                builder.AppendLine("</dl>");
            }

            if (ProductTypes.HasFlag(ProductTypes.Protein))
            {
                builder.AppendLine("<h3>Protein Question Responses</h3><dl>");
                builder.AppendFormat("<dt>How many acres do you have in production?</dt><dd>{0}</dd>", 
                    Convert.ToString(ProteinQuestions.AcresInProduction));
                builder.AppendFormat("<dt>Do you own the land in production?</dt><dd>{0}</dd>",
                    ProteinQuestions.OwnLand ? "Yes" : "No");

                builder.AppendFormat("<dt>What types and breeds of animals do you raise?</dt><dd>{0}</dd>", 
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.AnimalBreeds));
                builder.AppendFormat("<dt>Describe your feeding practices for your animals:</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.FeedingPractices));
                builder.AppendFormat("<dt>Describe the shelter for your animals:</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.AnimalShelter));
                builder.AppendFormat("<dt>Describe any hormones and/or antibiotics used:</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.HormonesAntiBiotics));
                builder.AppendFormat("<dt>How do you deal with diseases and parasites?</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.DiseasesAndParasites));
                builder.AppendFormat("<dt>When outdoors, do your animals have continuous access to grazeable pasture, fresh water, shade and shelter?</dt><dd>{0}</dd>",
                    ProteinQuestions.PastureWaterShadAndShelter ? "Yes" : "No");
                builder.AppendFormat("<dt>Who is your processor?</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(ProteinQuestions.Processor));
                builder.AppendFormat("<dt>Have you tested your soil for heavy metals or other contaminants?</dt><dd>{0}</dd>",
                    ProteinQuestions.SoilTested ? "Yes" : "No");

                builder.AppendLine("</dl>");
            }

            if (ProductTypes.HasFlag(ProductTypes.Seafood))
            {
                builder.AppendLine("<h3>Seafood Question Responses</h3><dl>");
                builder.AppendFormat("<dt>Source(s):</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(SeafoodQuestions.Source));
                builder.AppendFormat("<dt>Dock location:</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(SeafoodQuestions.DockLocation));
                builder.AppendFormat("<dt>Please provide additional information regarding practices, processes, sourcing, etc.</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(SeafoodQuestions.AdditionalInfo));

                builder.AppendLine("</dl>");
            }

            if (ProductTypes.HasFlag(ProductTypes.Bakery))
            {
                builder.AppendLine("<h3>Bakery Question Responses</h3><dl>");
                builder.AppendFormat("<dt>What products and materials are used in producing your products?</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(BakeryQuestions.MaterialsUsed));
                builder.AppendFormat("<dt>Please list any local ingredients used in your products:</dt><dd>{0}</dd>",
                    HttpContext.Current.Server.HtmlEncode(BakeryQuestions.LocalIngredients));

                builder.AppendLine("</dl>");
            }

            builder.AppendLine("<h3>Logistics</h3><dl>");
            builder.AppendFormat("<dt>How many spaces would you need?</dt><dd>{0}</dd>", 
                Convert.ToString(NumberOfSpaces));

            builder.AppendLine("<dt>On which dates would you attend the market?</dt><dd>");

            foreach (var dateTime in MarketDates)
            {
                builder.AppendFormat("{0}<br />", HttpContext.Current.Server.HtmlEncode(dateTime.ToShortDateString()));
            }

            builder.AppendFormat("<dt>Which market days are you applying for?</dt><dd>{0}</dd>", MarketDays);

            builder.AppendLine("</dd></dl>");

            builder.AppendLine("<h3>Follow Up</h3><dl>");
            builder.AppendFormat("<dt>Who should we follow up with?</dt><dd>{0}</dd>",
                HttpContext.Current.Server.HtmlEncode(ContactName));
            builder.AppendFormat("<dt>Phone Number</dt><dd>{0}</dd>",
                HttpContext.Current.Server.HtmlEncode(ContactPhone));
            builder.AppendFormat("<dt>Email</dt><dd>{0}</dd>",
                HttpContext.Current.Server.HtmlEncode(ContactEmail));

            builder.AppendLine("</dl>");
            builder.AppendLine("</body></html>");

            return builder.ToString();
        }

        #endregion Properties

        public int CompareTo(object obj)
        {
            if (!(obj is VendorApplication)) 
                throw new ArgumentException("Can only be compared to another VendorApplication");

            var target = obj as VendorApplication;

            return Name.CompareTo(target.Name);
        }
    }
}