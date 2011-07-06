namespace FarmersMarket.Web.Vendors
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Xml;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Helpers;
    using System.Xml.Serialization;

    public partial class Apply : Page
    {
        #region Fields

        private readonly Dictionary<String, ProductTypes> _productViewType;

        #endregion Fields

        #region Constructors

        public Apply()
        {
            Load += OnPageLoad;
            Init += OnPageInit;

            _productViewType = new Dictionary<String, ProductTypes>();
            _productViewType["produceQuestionsView"] = ProductTypes.Produce;
            _productViewType["proteinQuestionsView"] = ProductTypes.Protein;
            _productViewType["seafoodQuestionsView"] = ProductTypes.Seafood;
            _productViewType["bakeryQuestionsView"] = ProductTypes.Bakery;
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            UpdateViewNavigationButtons(multiView.ActiveViewIndex);
            base.OnPreRenderComplete(e);
        }

        #endregion Constructors

        //private const String KeyName = "VendorApplication";
        private VendorApplication _vendorApplication;

        #region Properties

        protected VendorApplication VendorApplication
        {
            get { return _vendorApplication ?? (_vendorApplication = new VendorApplication()); }
            set { _vendorApplication = value; }
/*

            var sessionValue = Session[KeyName];

                if (sessionValue != null)
                {
                    vendorApplication = sessionValue as VendorApplication;
                }
                else
                {
                    vendorApplication = new VendorApplication();
                    Session[KeyName] = vendorApplication;
                }

                return vendorApplication;
            }

            set { Session[KeyName] = value; }
*/
        }

        #endregion Properties

        #region Methods

        protected static bool TryParseDelimitedText(String text, IList<String> list)
        {
            if (String.IsNullOrEmpty(text)) return false;
            var items = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            list.Clear();
            foreach (var item in items) list.Add(item.Trim());
            return (list.Count > 0);
        }

        protected void LoadFormData()
        {
            var activeView = multiView.GetActiveView();

            LoadCachedApplicationData();

            if (activeView == null)
                throw new NullReferenceException("There is no active view!");

            if (activeView.ID.Equals("vendorInformationView"))
            {
                nameBox.Text = VendorApplication.Name;
                ownerBox.Text = VendorApplication.Owner;

                addressBox.Text = VendorApplication.MailingAddress.Address;
                cityBox.Text = VendorApplication.MailingAddress.City;
                zipBox.Text = VendorApplication.MailingAddress.ZipCode;

                if (VendorApplication.WebSite != null)
                    siteBox.Text = VendorApplication.WebSite.ToString();

                emergencyBox.Text = VendorApplication.EmergencyContact;

                productionAddressBox.Text = VendorApplication.ProductionAddress.Address;
                productionCityBox.Text = VendorApplication.ProductionAddress.City;
                productionZipBox.Text = VendorApplication.ProductionAddress.ZipCode;

                extensionAgentBox.Text = VendorApplication.ExtensionAgent;

                businessStructureList.SelectedIndex = (int)VendorApplication.BusinessStructure;

                descriptionBox.Text = VendorApplication.Description;
                ShowOnWebSite.SelectedIndex = VendorApplication.IncludeListingOnWebSite ? 0 : 1;
            }

            else if (activeView.ID.Equals("productView"))
            {
                vendorProducts.Text = String.Join(", ", VendorApplication.Products);

                foreach (ProductTypes productType in Enum.GetValues(typeof(ProductTypes)))
                {
                    if ((VendorApplication.ProductTypes & productType) != 0)
                    {
                        var valueToFind = Enum.GetName(typeof(ProductTypes), productType);
                        productTypes.Items.FindByValue(valueToFind).Selected = true;
                    }
                }

                if (VendorApplication.YearsPracticing > 0)
                    practicingExperienceList.SelectedIndex = (VendorApplication.YearsPracticing + 1);

                if (VendorApplication.YearsSelling > 0)
                    sellingExperienceList.SelectedIndex = (VendorApplication.YearsSelling + 1);

                vendorVenues.Text = String.Join(", ", VendorApplication.Venues);
            }

            else if (activeView.ID.Equals("produceQuestionsView"))
            {
                produceAcres.Text = Convert.ToString(VendorApplication.ProduceQuestions.AcresInProduction);
                produceOwned.SelectedIndex = VendorApplication.ProduceQuestions.OwnLand ? 0 : 1;
                produceWeeds.Text = VendorApplication.ProduceQuestions.PestControl;
                produceFertilizer.Text = VendorApplication.ProduceQuestions.FertilizerType;
                produceGreenhouse.SelectedIndex = VendorApplication.ProduceQuestions.Greenhouse ? 0 : 1;
                produceCsa.SelectedIndex = VendorApplication.ProduceQuestions.OfferCsa ? 0 : 1;
                produceDropOff.SelectedIndex = VendorApplication.ProduceQuestions.CsaDropOff ? 0 : 1;

                produceCsaPanel.Visible = (produceCsa.SelectedIndex == 0);
            }

            else if (activeView.ID.Equals("proteinQuestionsView"))
            {
                proteinAcres.Text = Convert.ToString(VendorApplication.ProteinQuestions.AcresInProduction);
                proteinBreeds.Text = VendorApplication.ProteinQuestions.AnimalBreeds;
                proteinFeeding.Text = VendorApplication.ProteinQuestions.FeedingPractices;
                proteinHousing.Text = VendorApplication.ProteinQuestions.AnimalShelter;
                proteinHormones.Text = VendorApplication.ProteinQuestions.HormonesAntiBiotics;
                proteinDisease.Text = VendorApplication.ProteinQuestions.DiseasesAndParasites;
                proteinPasture.SelectedIndex = VendorApplication.ProteinQuestions.PastureWaterShadAndShelter ? 0 : 1;
                proteinProcessor.Text = VendorApplication.ProteinQuestions.Processor;
                proteinSoil.SelectedIndex = VendorApplication.ProteinQuestions.SoilTested ? 0 : 1;
            }

            else if (activeView.ID.Equals("seafoodQuestionsView"))
            {
                seafoodSource.Text = VendorApplication.SeafoodQuestions.Source;
                seafoodDock.Text = VendorApplication.SeafoodQuestions.DockLocation;
                seafoodBoats.Text = VendorApplication.SeafoodQuestions.Boats;
                seafoodInfo.Text = VendorApplication.SeafoodQuestions.AdditionalInfo;
            }

            else if (activeView.ID.Equals("bakeryQuestionsView"))
            {
                bakeryMaterials.Text = VendorApplication.BakeryQuestions.MaterialsUsed;
                bakeryIngredients.Text = VendorApplication.BakeryQuestions.LocalIngredients;
            }

            else if (activeView.ID.Equals("organicView"))
            {
                organic.SelectedIndex = (VendorApplication.OrganicProducts.Count > 0) ? 0 : 1;

                if (VendorApplication.OrganicProducts.Count > 0)
                {
                    organicProducts.Visible = true;


                    foreach (ListItem item in organicProductList.Items)
                    {
                        if (VendorApplication.OrganicProducts.Contains(item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }
            }

            else if (activeView.ID.Equals("logisticsView"))
            {
                if (VendorApplication.NumberOfSpaces > 0)
                    numberOfSpaces.SelectedIndex = VendorApplication.NumberOfSpaces - 1;

                var checkBoxes = marketCalendar.GetAllControls()
                    .OfType<CheckBox>();

                foreach (var marketDate in VendorApplication.MarketDates)
                {
                    var controlId = String.Format("marketDay{0}", marketDate.ToString("yyyyMMdd"));

                    checkBoxes
                        .Where(cb => cb.ID.Equals(controlId, StringComparison.InvariantCultureIgnoreCase))
                        .Single()
                        .Checked = true;
                }

                marketDays.SelectedValue = Convert.ToInt32(VendorApplication.MarketDays).ToString();
            }

            else if (activeView.ID.Equals("followUpView"))
            {
                contactBox.Text = VendorApplication.ContactName;
                phoneBox.Text = VendorApplication.ContactPhone;
                emailBox.Text = VendorApplication.ContactEmail;
            }

            //TryParseDelimitedText(organicProductList.Text, VendorApplication.OrganicProducts);
        }

        protected void OnBack(object sender, EventArgs e)
        {
            SaveFormData();

            int newViewIndex = multiView.ActiveViewIndex - 1;

            while ((newViewIndex > 0) &&
                ShouldSkipView(newViewIndex))
            {
                newViewIndex--;
            }

            multiView.ActiveViewIndex = newViewIndex;

            LoadFormData();
        }

        protected void OnClickOrganic(object sender, EventArgs e)
        {
            organicProducts.Visible = (organic.SelectedIndex == 0);
        }

        protected void OnNext(object sender, EventArgs e)
        {
            SaveFormData();

            int newViewIndex = multiView.ActiveViewIndex + 1;

            while ((newViewIndex < multiView.Views.Count) &&
                ShouldSkipView(newViewIndex))
            {
                newViewIndex++;
            }

            multiView.ActiveViewIndex = newViewIndex;

            LoadFormData();
        }

        protected void OnPageInit(object sender, EventArgs e)
        {
            LoadCachedApplicationData();

            organicProductList.Items.Clear();

            if (VendorApplication.Products.Count > 0)
            {
                foreach (var item in VendorApplication.Products.Select(product => new ListItem(product)))
                {
                    organicProductList.Items.Add(item);
                }
            }

            var marketDay = new DateTime(2011, 4, 1);
            var daysTilSaturday = DayOfWeek.Saturday - marketDay.DayOfWeek;
            marketDay = marketDay.AddDays(daysTilSaturday);
            var marketEnds = marketDay.AddYears(1);
            int currentMonth;

            // Market is closed on 11/26
            var marketClosed = new[] { new DateTime(2011, 11, 26) };

            while (marketDay.CompareTo(marketEnds) < 0)
            {
                var row = new TableRow { ID = String.Format("month{0}", marketDay.Month.ToString("D2")) };
                var cells = new[] { new TableCell(), new TableCell(), new TableCell(), new TableCell(), new TableCell(), new TableCell() };

                cells[0].Controls.Add(new Literal { Text = marketDay.ToString("MMMM") });

                currentMonth = marketDay.Month;

                for (var week = 1; week <= 5; week++)
                {
                    var checkBox = new CheckBox
                                       {
                                           Text = marketDay.ToString("dd"),
                                           ID =
                                               String.Format("marketDay{0}{1}{2}",
                                                             marketDay.Year.ToString("D4"),
                                                             marketDay.Month.ToString("D2"),
                                                             marketDay.Day.ToString("D2")),
                                           Enabled = !marketClosed.Contains(marketDay),
                                           ToolTip = marketDay.ToLongDateString(),
                                       };

                    if (!String.IsNullOrEmpty(VendorApplication.Name))
                    {
                        checkBox.Checked = VendorApplication.MarketDates.Contains(marketDay);
                    }
                    else
                    {
                        checkBox.Checked = !marketClosed.Contains(marketDay);
                    }

                    cells[week].Controls.Add(checkBox);

                    marketDay = marketDay.AddDays(7);

                    if (marketDay.Month != currentMonth)
                        break;
                }

                row.Cells.AddRange(cells);
                marketCalendar.Rows.Add(row);
            }
        }

        protected void OnPageLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFormData();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Debug.WriteLine("OnPreRender");

            base.OnPreRender(e);
        }

        protected void OnSelectCsa(object sender, EventArgs e)
        {
            produceCsaPanel.Visible = (produceCsa.SelectedIndex == 0);
        }

        protected void EmailConfirmation()
        {
            var mail = new MailMessage();

            mail.To.Add(new MailAddress("info@westernwakefarmersmarket.org", "Western Wake Farmers' Market"));
            mail.Subject = String.Format("Vendor Application: {0}", VendorApplication.Name);

            if (!(String.IsNullOrEmpty(VendorApplication.ContactEmail) ||
                String.IsNullOrEmpty(VendorApplication.ContactName)))
            {
                var vendorContact = new MailAddress(VendorApplication.ContactEmail,
                    VendorApplication.ContactName);

                mail.From = vendorContact;
                mail.ReplyToList.Add(vendorContact);
                mail.CC.Add(vendorContact);
            }
            else
            {
                mail.From = new MailAddress("system@westernwakefarmersmarket.org", "Western Wake Farmers' Market");
            }

            mail.Body = VendorApplication.ToHtml();
            mail.IsBodyHtml = true;

            if (!String.IsNullOrEmpty(VendorApplication.LogoImagePath))
            {
                mail.Attachments.Add(new Attachment(VendorApplication.LogoImagePath));
            }

            var smtp = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["SMTP"],
                Credentials = new System.Net.NetworkCredential(
                    ConfigurationManager.AppSettings["FROMEMAIL"],
                    ConfigurationManager.AppSettings["FROMPWD"]),
                EnableSsl = true
            };

            try
            {
                smtp.Send(mail);

                Server.Transfer("~/Vendors/ApplicationSubmitted.aspx");
            }
            catch (SmtpException exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        protected void OnSubmit(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SaveFormData();
                // EmailConfirmation();
            }
        }

        private void LoadCachedApplicationData()
        {
            var appIdCookie = Request.Cookies["VendorApplicationId"];

            if (appIdCookie != null)
            {
                var applicationXmlFile = Path.Combine(Server.MapPath("~/Vendors/Applications"), 
                    String.Format("{0}.xml", appIdCookie.Value));

                if (File.Exists(applicationXmlFile))
                {
                    using (var textReader = new StreamReader(applicationXmlFile))
                    {
                        var xmlSerializer = new XmlSerializer(VendorApplication.GetType());
                        _vendorApplication = (VendorApplication)xmlSerializer.Deserialize(textReader);
                        textReader.Close();
                    }
                }
            }
        }

        private void CacheApplicationData()
        {
            var appIdCookie = Request.Cookies["VendorApplicationId"];

            if (appIdCookie == null)
            {
                appIdCookie = new HttpCookie("VendorApplicationId",
                                             DateTime.Now.Ticks.ToString())
                                  {
                                      Expires = DateTime.Now.AddYears(1)
                                  };
                                             // DateTime.Now.Ticks.ToString()) { Expires = new DateTime(2011, 3, 14) };

                Response.AppendCookie(appIdCookie);
            }

            var applicationXmlFile = Path.Combine(Server.MapPath("~/Vendors/Applications"),
                String.Format("{0}.xml", appIdCookie.Value));

            using (var xmlWriter = new XmlTextWriter(applicationXmlFile, Encoding.UTF8))
            {
                var xmlSerializer = new XmlSerializer(VendorApplication.GetType());
                xmlSerializer.Serialize(xmlWriter, VendorApplication);
                xmlWriter.Close();
            }
        }
        
        protected void SaveFormData()
        {
            var activeView = multiView.GetActiveView();

            if (activeView == null)
                throw new NullReferenceException("There is no active view!");

            LoadCachedApplicationData();

            if (activeView.ID.Equals("vendorInformationView"))
            {
                VendorApplication.Name = nameBox.Text;
                VendorApplication.Owner = ownerBox.Text;
                VendorApplication.MailingAddress.Address = addressBox.Text;
                VendorApplication.MailingAddress.City = cityBox.Text;
                VendorApplication.MailingAddress.State = "NC";
                VendorApplication.MailingAddress.ZipCode = zipBox.Text;

                if (!String.IsNullOrEmpty(siteBox.Text))
                {
                    if (Uri.IsWellFormedUriString(siteBox.Text, UriKind.Absolute))
                    {
                        VendorApplication.WebSite = new Uri(siteBox.Text);
                    }
                }

                VendorApplication.EmergencyContact = emergencyBox.Text;

                if (!String.IsNullOrEmpty(productionAddressBox.Text))
                {
                    VendorApplication.ProductionAddress.Address = productionAddressBox.Text;
                    VendorApplication.ProductionAddress.City = productionCityBox.Text;
                    VendorApplication.ProductionAddress.State = "NC";
                    VendorApplication.ProductionAddress.ZipCode = productionZipBox.Text;
                }

                VendorApplication.ExtensionAgent = extensionAgentBox.Text;

                BusinessStructure businessStructure;

                if (Enum.TryParse(businessStructureList.SelectedValue, out businessStructure))
                {
                    VendorApplication.BusinessStructure = businessStructure;
                }

                VendorApplication.Description = descriptionBox.Text;

                if (logoUpload.HasFile)
                {
                    var imagePath = Path.Combine(Server.MapPath("~/Images/Uploads"),
                        Convert.ToString(DateTime.Now.Ticks));

                    imagePath += Path.GetExtension(logoUpload.FileName);

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                    logoUpload.SaveAs(imagePath);
                    VendorApplication.LogoImagePath = imagePath;
                }

                VendorApplication.IncludeListingOnWebSite = (ShowOnWebSite.SelectedIndex == 0);
            }

            else if (activeView.ID.Equals("productView"))
            {
                TryParseDelimitedText(vendorProducts.Text, VendorApplication.Products);

                VendorApplication.ProductTypes = 0;

                foreach (var item in productTypes.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    ProductTypes selectedType;

                    if (Enum.TryParse(item.Value, out selectedType))
                    {
                        VendorApplication.ProductTypes |= selectedType;
                    }
                }

                TryParseDelimitedText(vendorVenues.Text, VendorApplication.Venues);

                if (practicingExperienceList.SelectedIndex > 0)
                {
                    Int32 yearsPracticing;

                    if (Int32.TryParse(practicingExperienceList.SelectedValue, out yearsPracticing))
                        VendorApplication.YearsPracticing = yearsPracticing;
                }

                if (sellingExperienceList.SelectedIndex > 0)
                {
                    Int32 yearsSelling;

                    if (Int32.TryParse(sellingExperienceList.SelectedValue, out yearsSelling))
                        VendorApplication.YearsSelling = yearsSelling;
                }
            }

            else if (activeView.ID.Equals("produceQuestionsView"))
            {
                if (!String.IsNullOrEmpty(produceAcres.Text))
                {
                    Int32 acresInProduction;

                    if (Int32.TryParse(produceAcres.Text, out acresInProduction))
                    {
                        VendorApplication.ProduceQuestions.AcresInProduction = acresInProduction;
                    }
                }

                VendorApplication.ProduceQuestions.OwnLand = (produceOwned.SelectedIndex == 0);
                VendorApplication.ProduceQuestions.PestControl = produceWeeds.Text;
                VendorApplication.ProduceQuestions.FertilizerType = produceFertilizer.Text;
                VendorApplication.ProduceQuestions.Greenhouse = (produceGreenhouse.SelectedIndex == 0);
                VendorApplication.ProduceQuestions.OfferCsa = (produceCsa.SelectedIndex == 0);
                VendorApplication.ProduceQuestions.CsaDropOff = (produceDropOff.SelectedIndex == 0);
            }

            else if (activeView.ID.Equals("proteinQuestionsView"))
            {
                if (!String.IsNullOrEmpty(proteinAcres.Text))
                {
                    Int32 acresInProduction;

                    if (Int32.TryParse(proteinAcres.Text, out acresInProduction))
                    {
                        VendorApplication.ProteinQuestions.AcresInProduction = acresInProduction;
                    }
                }

                VendorApplication.ProteinQuestions.AnimalBreeds = proteinBreeds.Text;
                VendorApplication.ProteinQuestions.FeedingPractices = proteinFeeding.Text;
                VendorApplication.ProteinQuestions.AnimalShelter = proteinHousing.Text;
                VendorApplication.ProteinQuestions.HormonesAntiBiotics = proteinHormones.Text;
                VendorApplication.ProteinQuestions.DiseasesAndParasites = proteinDisease.Text;
                VendorApplication.ProteinQuestions.PastureWaterShadAndShelter = (proteinPasture.SelectedIndex == 0);
                VendorApplication.ProteinQuestions.Processor = proteinProcessor.Text;
                VendorApplication.ProteinQuestions.SoilTested = (proteinSoil.SelectedIndex == 0);
            }

            else if (activeView.ID.Equals("seafoodQuestionsView"))
            {
                VendorApplication.SeafoodQuestions.Source = seafoodSource.Text;
                VendorApplication.SeafoodQuestions.DockLocation = seafoodDock.Text;
                VendorApplication.SeafoodQuestions.Boats = seafoodBoats.Text;
                VendorApplication.SeafoodQuestions.AdditionalInfo = seafoodInfo.Text;
            }

            else if (activeView.ID.Equals("bakeryQuestionsView"))
            {
                VendorApplication.BakeryQuestions.MaterialsUsed = bakeryMaterials.Text;
                VendorApplication.BakeryQuestions.LocalIngredients = bakeryIngredients.Text;
            }

            else if (activeView.ID.Equals("organicView"))
            {
                VendorApplication.OrganicProducts.Clear();

                foreach (var item in organicProductList.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    VendorApplication.OrganicProducts.Add(item.Text);
                }
            }

            else if (activeView.ID.Equals("logisticsView"))
            {
                if (numberOfSpaces.SelectedIndex >= 0)
                {
                    Int32 numSpaces;

                    if (Int32.TryParse(numberOfSpaces.SelectedValue, out numSpaces))
                        VendorApplication.NumberOfSpaces = numSpaces;
                }

                VendorApplication.MarketDates.Clear();

                var checkedBoxes = marketCalendar.GetAllControls()
                    .OfType<CheckBox>()
                    .Where(cb => cb.Checked);

                foreach (var checkBox in checkedBoxes)
                {
                    var datePart = checkBox.ID.Substring(checkBox.ID.Length - 8);
                    var marketDate = DateTime.ParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture);

                    VendorApplication.MarketDates.Add(marketDate);
                }

                VendorApplication.MarketDays = (MarketDaysOfWeek)Convert.ToInt32(marketDays.SelectedValue);
            }

            else if (activeView.ID.Equals("followUpView"))
            {
                VendorApplication.ContactName = contactBox.Text;
                VendorApplication.ContactPhone = phoneBox.Text;
                VendorApplication.ContactEmail = emailBox.Text;
            }

            //Session["application"] = VendorApplication;
            CacheApplicationData();
        }

        protected bool ShouldSkipView(int viewIndex)
        {
            var viewId = multiView.Views[viewIndex].ID;
            if (!_productViewType.ContainsKey(viewId)) return false;

            var productType = _productViewType[viewId];
            return ((VendorApplication.ProductTypes & productType) == 0);
        }

        protected void UpdateViewNavigationButtons(int activeViewIndex)
        {
            backButton.Enabled = (activeViewIndex > 0);
            nextButton.Visible = (activeViewIndex < (multiView.Views.Count - 1));
        }

        #endregion Methods
    }
}