using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace FarmersMarket.Web.Tests
{
    /// <summary>
    /// Represents a result from the W3C Markup Validation Service.
    /// </summary>
    public class W3CValidityCheckResult
    {
        public bool IsValid { get; set; }
        public int WarningsCount { get; set; }
        public int ErrorsCount { get; set; }
        public string Body { get; set; }
    }

    static class TestHelper
    {
        private static AutoResetEvent _w3cValidatorBlock = new AutoResetEvent(true);

        private static void ResetBlocker(object state)
        {
            // Ensures that W3C Validator service is not called more than once a second
            Thread.Sleep(1000);
            _w3cValidatorBlock.Set();
        }

        /// <summary>
        /// Determines whether the ASP.NET page returns valid HTML by checking the response against the W3C Markup Validator.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        /// <returns>
        /// An object representing indicating whether the HTML generated is valid.
        /// </returns>
        public static W3CValidityCheckResult ReturnsValidHtml(TestContext testContext)
        {
            var result = new W3CValidityCheckResult();
            WebHeaderCollection w3cResponseHeaders = new WebHeaderCollection();

            using (var webClient = new WebClient())
            {
                string html = GetPageHtml(webClient, testContext.RequestedPage.Request.Url);

                // Send to W3C validator
                string w3cUrl = "http://validator.w3.org/check";
                webClient.Encoding = System.Text.Encoding.UTF8;

                var values = new NameValueCollection();
                values.Add("fragment", html);
                values.Add("prefill", "0");
                values.Add("group", "0");
                values.Add("doctype", "inline");

                try
                {
                    _w3cValidatorBlock.WaitOne();
                    byte[] w3cRawResponse = webClient.UploadValues(w3cUrl, values);
                    result.Body = Encoding.UTF8.GetString(w3cRawResponse);
                    w3cResponseHeaders.Add(webClient.ResponseHeaders);

                    String responsePath = Path.Combine(Directory.GetCurrentDirectory(),
                            String.Format("{0}.html", testContext.TestName));

                    FileStream responseStream = new FileStream(responsePath, FileMode.CreateNew);

                    responseStream.Write(w3cRawResponse, 0, w3cRawResponse.Length);
                    responseStream.Close();

                    testContext.AddResultFile(responsePath);
                }
                finally
                {
                    ThreadPool.QueueUserWorkItem(ResetBlocker); // Reset on background thread
                }
            }

            // Extract result from response headers
            int warnings = -1;
            int errors = -1;
            int.TryParse(w3cResponseHeaders["X-W3C-Validator-Warnings"], out warnings);
            int.TryParse(w3cResponseHeaders["X-W3C-Validator-Errors"], out errors);
            string status = w3cResponseHeaders["X-W3C-Validator-Status"];

            result.WarningsCount = warnings;
            result.ErrorsCount = errors;
            result.IsValid = (!String.IsNullOrEmpty(status) && status.Equals("Valid", StringComparison.InvariantCultureIgnoreCase));

            return result;
        }

        private static string GetPageHtml(WebClient webClient, Uri url)
        {
            // Pretend to be Firefox 3 so that ASP.NET renders compliant HTML
            webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1 (.NET CLR 3.5.30729)";
            webClient.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            webClient.Headers["Accept-Language"] = "en-au,en-us;q=0.7,en;q=0.3";

            // Read page HTML
            string html = "";
            using (Stream responseStream = webClient.OpenRead(url))
            {
                using (var sr = new StreamReader(responseStream))
                {
                    html = sr.ReadToEnd();
                    sr.Close();
                }
            }

            return html;
        }
    }
}
