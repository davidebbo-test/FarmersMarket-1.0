namespace FarmersMarket.Web.Controls
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    using System.Xml;
    using System.Xml.XPath;

    using FarmersMarket.Web.gov.weather.www;

    /// <summary>
    /// ASP.net user control to render weather forecast for the upcoming Market
    /// </summary>
    public partial class WeatherForecast : System.Web.UI.UserControl
    {
        #region Fields

        // static instance of WeatherForecastTimer causes timer to get kicked off on
        // app domain startup
        private static readonly WeatherForecastTimer Timer = new WeatherForecastTimer();

        // stores a local copy of the weather forecast data retrieved by the timer
        private WeatherForecastData _forecastData;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the weather forecast data from the WeatherForecastTimer instance
        /// </summary>
        /// <value>The data.</value>
        protected WeatherForecastData Data
        {
            get
            {
                if (_forecastData == null)
                {
                    WeatherForecastData forecastData = Timer.GetForecastData();
                    _forecastData = forecastData ?? new WeatherForecastData();
                }

                return _forecastData;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> 
        /// object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that 
        /// receives the server control content.</param>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Data != null) && Data.IsValid())
            {
                moreInfoLink.NavigateUrl = Data.MoreInformationUri;

                forecastIcon.ImageUrl = Data.IconUri;
                forecastIcon.AlternateText = Data.Source;

                // show the 'open rain or shine' advisory if probability of precipitation is > 20%
                if (Data.ProbabilityOfPrecipitation >= 20)
                {
                    Advisory.Style.Remove("display");
                }

                base.Render(writer);
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// Encapsulates the forecast data returned by the National Weather Service
    /// </summary>
    public class WeatherForecastData : ICloneable
    {
        #region Constructors

        #endregion Constructors

        #region Properties

        public DateTime ForecastDateTime
        {
            get; private set;
        }

        public string IconUri
        {
            get; private set;
        }

        public string MoreInformationUri
        {
            get; private set;
        }

        public int ProbabilityOfPrecipitation
        {
            get; private set;
        }

        public string Source
        {
            get; private set;
        }

        public int TemperatureHigh
        {
            get; private set;
        }

        public int TemperatureLow
        {
            get; private set;
        }

        public int WindSpeedHigh
        {
            get; private set;
        }

        public int WindSpeedLow
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Parses the specified XML response from the National Weather Service (NWS)
        /// to the appropriate data fields.
        /// </summary>
        /// <param name="xml">The XML response from the NWS.</param>
        /// <returns></returns>
        public static WeatherForecastData Parse(string xml)
        {
            var data = new WeatherForecastData();

            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);

                data.Source = doc.SelectSingleNode("//title/text()").InnerText;

                data.ForecastDateTime = DateTime.Parse(doc.SelectSingleNode(
                    "/dwml/data/time-layout[1]/start-valid-time[1]/text()").InnerText);

                XmlNodeList tempNodes = doc.SelectNodes("/dwml/data/parameters/temperature[@type=\"apparent\"]/value");

                data.TemperatureHigh = Convert.ToInt32(doc.SelectSingleNode(
                    "/dwml/data/parameters/temperature[@type=\"apparent\"]/value[1]/text()").InnerText);

                if ((tempNodes != null) && (tempNodes.Count > 1))
                {
                    data.TemperatureLow = Convert.ToInt32(doc.SelectSingleNode(
                        "/dwml/data/parameters/temperature[@type=\"apparent\"]/value[2]/text()").InnerText);

                    // swap the high and low values if necessary
                    if (data.TemperatureLow > data.TemperatureHigh)
                    {
                        data.TemperatureLow ^= data.TemperatureHigh;
                        data.TemperatureHigh ^= data.TemperatureLow;
                        data.TemperatureLow ^= data.TemperatureHigh;
                    }
                }

                data.IconUri = doc.SelectSingleNode("//icon-link").InnerText;

                data.MoreInformationUri = doc.SelectSingleNode("//moreWeatherInformation/text()").InnerText;

                data.ProbabilityOfPrecipitation = Convert.ToInt32(doc.SelectSingleNode(
                    "/dwml/data/parameters/probability-of-precipitation/value/text()").InnerText);

                data.WindSpeedHigh = Convert.ToInt32(doc.SelectSingleNode(
                    "/dwml/data/parameters/wind-speed/value[1]/text()").InnerText);

                tempNodes = doc.SelectNodes("/dwml/data/parameters/wind-speed/value");

                if ((tempNodes != null) && (tempNodes.Count > 1))
                {
                    data.WindSpeedLow = Convert.ToInt32(doc.SelectSingleNode(
                        "/dwml/data/parameters/wind-speed/value[2]/text()").InnerText);
                }
            }
            catch (NullReferenceException exNull)
            {
                Debug.WriteLine(exNull.Message);
                data.Source = String.Empty;
            }
            catch (InvalidOperationException exOp)
            {
                Debug.WriteLine(exOp.Message);
                data.Source = String.Empty;
            }
            catch (XPathException exXPath)
            {
                Debug.WriteLine(exXPath.Message);
                data.Source = String.Empty;
            }

            return data;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public Object Clone()
        {
            return MemberwiseClone();
        }

        public bool IsValid()
        {
            return (!(String.IsNullOrEmpty(IconUri) ||
                String.IsNullOrEmpty(Source)));
        }

        #endregion Methods
    }

    /// <summary>
    /// Manages an instance of System.Threading.Timer to periodically update the weather
    /// forecast for the upcoming Market.
    /// </summary>
    internal class WeatherForecastTimer : IDisposable
    {
        #region Fields

        private int _disposed;
        private WeatherForecastData _forecastData;
        private readonly ReaderWriterLock _forecastDataLock = new ReaderWriterLock();
        private int _inTimerCallback;
        private readonly EventHandler _onAppDomainUnload;
        private Timer _timer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastTimer"/> class.
        /// </summary>
        public WeatherForecastTimer()
        {
            // assume failure
            bool dispose = true;

            try
            {
                // register event handler on unload of the app domain to dispose the timer
                AppDomain appDomain = Thread.GetDomain();

                var onAppDomainUnload = new EventHandler(OnAppDomainUnload);
                appDomain.DomainUnload += onAppDomainUnload;
                _onAppDomainUnload = onAppDomainUnload;

                WeatherForecastData forecastData = GetForecastForUpcomingMarket();

                if (forecastData != null)
                {
                    _forecastDataLock.AcquireWriterLock(Timeout.Infinite);
                    _forecastData = forecastData;
                    _forecastDataLock.ReleaseWriterLock();
                }

                // if we get the forecast successfully, start the timer in 4 hours, otherwise
                // try again in 2 minutes
                var dueTime = ((forecastData != null) && forecastData.IsValid()) ?
                    new TimeSpan(4, 0, 0) : new TimeSpan(0, 2, 0);

                // create the timer
                _timer = new Timer(UpdateWeatherForecast, null, dueTime, new TimeSpan(4, 0, 0));

                // if we've gotten this far, we don't need to dispose ourselves
                dispose = false;
            }
            finally
            {
                if (dispose)
                {
                    Dispose();
                }
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Frees the System.Threading.Timer instance associated with this object
        /// </summary>
        public void Dispose()
        {
            // skip if this object has already been disposed
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                // unhook domain events
                AppDomain appDomain = Thread.GetDomain();
                if (_onAppDomainUnload != null)
                {
                    appDomain.DomainUnload -= _onAppDomainUnload;
                }

                // dispose the timer — very important, since timer callbacks can attempt to
                // reenter the domain after it has been unloaded, and this will result in
                // an unhandled exception that will crash the process.
                Timer timer = _timer;

                if (timer != null && Interlocked.CompareExchange(ref _timer, null, timer) == timer)
                {
                    timer.Dispose();
                }

                // wait for the timercallback to exit, because if it’s still running you
                // can end up with a CannotUnloadAppDomainException or some other exception
                // that will crash the process.
                while (_inTimerCallback != 0)
                {
                    Thread.Sleep(100);
                }

                GC.SuppressFinalize(this);
            }
        }

        public WeatherForecastData GetForecastData()
        {
            WeatherForecastData data;

            try
            {
                _forecastDataLock.AcquireReaderLock(100);
                data = (WeatherForecastData)_forecastData.Clone();
                _forecastDataLock.ReleaseReaderLock();
            }
            catch (ApplicationException)
            {
                data = new WeatherForecastData();
            }

            return data;
        }

        /// <summary>
        /// Gets the forecast for upcoming market day.
        /// </summary>
        /// <returns></returns>
        private static WeatherForecastData GetForecastForUpcomingMarket()
        {
            WeatherForecastData result;

            // determine the local date/time for the start of this Saturday's market
            int daysTilSaturday = DayOfWeek.Saturday - DateTime.Today.DayOfWeek;
            DateTime marketStarts = DateTime.Today.AddDays(daysTilSaturday).AddHours(8);

            // geographic location of Carpterter Village
            const decimal latitude = (decimal)35.8188612;
            const decimal longitude = (decimal)-78.8594969;

            // create an instance of the web service proxy
            var weatherFetcher = new ndfdXML {Proxy = WebRequest.DefaultWebProxy};

            // setup the parameters to tell the service what data we want
            // see http://www.nws.noaa.gov/forecasts/xml/docs/elementInputNames.php for parameters
            var weatherParams = new weatherParametersType
                                    {
                                        appt = true,
                                        icons = true,
                                        maxt = true,
                                        mint = true,
                                        pop12 = true,
                                        rh = true,
                                        wx = true,
                                        wwa = true,
                                        wspd = true
                                    };

            try
            {
                result = WeatherForecastData.Parse(weatherFetcher.NDFDgen(latitude, longitude, "time-series",
                    marketStarts.ToUniversalTime(), marketStarts.AddHours(4).ToUniversalTime(), weatherParams));
            }
            catch (Exception)
            {
                result = new WeatherForecastData();
            }

            return result;
        }

        /// <summary>
        /// Called when the AppDomain is unloaded
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnAppDomainUnload(Object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Updates the weather forecast.
        /// </summary>
        /// <param name="state">The state (required for TimerCallback)</param>
        private void UpdateWeatherForecast(Object state)
        {
            // timer callbacks can queue up and fire all at once. Of course in this case,
            // the interval is 4 hours, so we won’t see any callbacks queue up, but if the
            // interval was a few seconds, it would be possible.
            if (Interlocked.Exchange(ref _inTimerCallback, 1) != 0) {
                return;
            }

            try
            {
                // if someone disposed us, do nothing
                if (_disposed == 1)
                {
                    return;
                }

                // attempt to retrieve the weather forecast data
                WeatherForecastData updatedForecast = GetForecastForUpcomingMarket();

                if (updatedForecast != null)
                {
                    _forecastDataLock.AcquireWriterLock(Timeout.Infinite);
                    _forecastData = updatedForecast;
                    _forecastDataLock.ReleaseWriterLock();
                }

                // if we succeed, update in 4 hours, otherwise retry in 2 minutes
                TimeSpan newTimeSpan = ((updatedForecast != null) && updatedForecast.IsValid()) ?
                    new TimeSpan(4, 0, 0) : new TimeSpan(0, 2, 0);

                _timer.Change(newTimeSpan, newTimeSpan);
            }
            finally
            {
                Interlocked.Exchange(ref _inTimerCallback, 0);
            }
        }

        #endregion Methods
    }
}