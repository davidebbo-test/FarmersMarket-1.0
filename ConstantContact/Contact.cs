namespace ConstantContact
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public class Contact : ICloneable
    {
        #region Fields

        public String[] CustomField = new String[15];

        protected List<ContactList> ContactLists = new List<ContactList>();

        private static readonly Contact Empty = new Contact();

        #endregion Fields

        #region Constructors

        public Contact()
        {
            LastUpdateTime = DateTimeOffset.Now;
        }

        public Contact(String firstName, String lastName, String emailAddress)
            : this()
        {
            if (String.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException("emailAddress", "A valid email address is required");

            if (emailAddress.Length > 80)
                throw new ArgumentException("Length of email address must be less than or equal to 80 characters", "emailAddress");

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        #endregion Constructors

        #region Properties

        public String Addr1
        {
            get; set;
        }

        public String Addr2
        {
            get; set;
        }

        public String Addr3
        {
            get; set;
        }

        public String City
        {
            get; set;
        }

        public String CompanyName
        {
            get; set;
        }

        public Boolean Confirmed
        {
            get; set;
        }

        public String CountryCode
        {
            get; set;
        }

        public String CountryName
        {
            get; set;
        }

        public String EmailAddress
        {
            get; set;
        }

        public ContactEmailPreference EmailType
        {
            get; set;
        }

        public String FirstName
        {
            get; set;
        }

        public String HomePhone
        {
            get; set;
        }

        public Uri Id
        {
            get; internal set;
        }

        public DateTimeOffset InsertTime
        {
            get; set;
        }

        public String JobTitle
        {
            get; set;
        }

        public String LastName
        {
            get; set;
        }

        public DateTimeOffset LastUpdateTime
        {
            get; set;
        }

        public string Link
        {
            get; internal set;
        }

        public List<ContactList> Lists
        {
            get { return ContactLists; }
        }

        public String MiddleName
        {
            get; set;
        }

        public String Name
        {
            get { return String.Format("{1}, {0}", FirstName, LastName); }
            set
            {
                int delimiterPosition = value.LastIndexOf(',');

                if (delimiterPosition < 1)
                    throw new ArgumentException("Expected Name in the format '[Last], [First]'", "Value");

                FirstName = value.Substring(delimiterPosition + 1).Trim();
                LastName = value.Substring(0, delimiterPosition).Trim();
            }
        }

        public String Note
        {
            get; set;
        }

        public OptInSource OptInSource
        {
            get; set;
        }

        public DateTimeOffset OptInTime
        {
            get; set;
        }

        public String PostalCode
        {
            get; set;
        }

        public String StateCode
        {
            get; set;
        }

        public String StateName
        {
            get; set;
        }

        public ContactStatus Status
        {
            get; set;
        }

        public String SubPostalCode
        {
            get; set;
        }

        public String WorkPhone
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public static Contact FromEmail(NetworkCredential credentials, String email)
        {
            int delimiterPosition = credentials.UserName.IndexOf('%');
            if (delimiterPosition <= 0)
                throw new ArgumentException("Specified username is missing the '%' delimiter", "credentials");

            var customerName = credentials.UserName.Substring(delimiterPosition + 1);
            const String uriFormat = "{0}/ws/customers/{1}/contacts?email={2}";

            var requestUri = new Uri(String.Format(uriFormat, Constants.ApiEndpoint, customerName, email));

            var request = WebRequest.Create(requestUri) as HttpWebRequest;

            if (request != null)
            {
                request.Credentials = credentials;
                request.Method = "GET";
                request.ContentType = "application/atom+xml";

                // Get response
                using (var webResponse = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    if (webResponse != null)
                    {
                        var xmlReader = XmlReader.Create(webResponse.GetResponseStream());

                        if (webResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var atomResponse = new Atom10FeedFormatter();

                            if (atomResponse.CanRead(xmlReader))
                            {
                                atomResponse.ReadFrom(xmlReader);
                                return new ContactContent(atomResponse.Feed.Items.First()).Contact;
                            }
                        }
                    }
                }
            }

            return Empty;
        }

        public Object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (!(obj is Contact)) return false;
            if (Id == null) return (((Contact)(obj)).Id == null);
            return ((Contact)(obj)).Id.Equals(Id);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (Link != null) ? Link.GetHashCode() : 0;
        }

        #endregion Methods
    }
}