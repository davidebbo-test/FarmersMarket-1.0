using System;
using System.Diagnostics;
using FarmersMarket.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace FarmersMarket.Web.Tests
{
    
    
    /// <summary>
    ///This is a test class for _DefaultTest and is intended
    ///to contain all _DefaultTest Unit Tests
    ///</summary>
    [TestClass()]
    public class _DefaultTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        
        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the home page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the home page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/")]
        [DeploymentItem("Web.dll")]
        public void ValidateHomePage()
        {
            //_Default_Accessor target = new _Default_Accessor();
            //target.Page_Load(null, EventArgs.Empty);

            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the About page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the about page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/About/")]
        [DeploymentItem("Web.dll")]
        public void ValidateAboutPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Contact page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the contact page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Contact/")]
        [DeploymentItem("Web.dll")]
        public void ValidateContactPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Learn page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the learn page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Learn/")]
        [DeploymentItem("Web.dll")]
        public void ValidateLearnPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Season page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the season page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Season/")]
        [DeploymentItem("Web.dll")]
        public void ValidateSeasonPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Sponsors page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the sponsors page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Sponsors/")]
        [DeploymentItem("Web.dll")]
        public void ValidateSponsorsPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Vendors page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the vendors page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Vendors/")]
        [DeploymentItem("Web.dll")]
        public void ValidateVendorsPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Vendor Application page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the vendor application page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Vendors/Apply.aspx")]
        [DeploymentItem("Web.dll")]
        public void ValidateVendorsApplyPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Vendor Information page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the vendor information page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Vendors/Information.aspx")]
        [DeploymentItem("Web.dll")]
        public void ValidateVendorsInformationPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }

        /// <summary>
        /// Use the W3C Validation Service to verify the XHTML output of the Vendor Rules page
        /// </summary>
        [TestMethod()]
        [Description("Tests that the HTML outputted by the vendor rules page is valid using the W3C validator")]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%SolutionDir%\\Web")]
        [UrlToTest("http://localhost/Vendors/Rules.aspx")]
        [DeploymentItem("Web.dll")]
        public void ValidateVendorsRulesPage()
        {
            Assert.IsTrue(TestHelper.ReturnsValidHtml(this.TestContext).IsValid,
                String.Format(Resources.W3CValidationFailure, TestContext.RequestedPage.AppRelativeVirtualPath));
        }
    }
}
