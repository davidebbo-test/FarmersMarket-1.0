namespace ConstantContact
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public class ContactContent : SyndicationContent
    {
        #region Fields

        public readonly Contact Contact;
        public List<Uri> ContactLists = new List<Uri>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContent"/> class.
        /// </summary>
        /// <param name="contact">The contact to create syndication content for</param>
        public ContactContent(Contact contact)
        {
            Contact = contact;
        }

        public ContactContent(SyndicationItem item)
        {
            SyndicationContent contactContent = item.Content;

            if (contactContent == null)
                throw new ArgumentNullException(@"item");

            if (String.Compare(contactContent.Type, Constants.ContactContentType, true,
                CultureInfo.InvariantCulture) != 0)
            {
                throw new InvalidDataException(String.Format("Expected content type {0} but encountered {1}",
                    Constants.ContactContentType, contactContent.Type));
            }

            XmlDictionaryReader xmlReader =
                ((XmlSyndicationContent)(contactContent)).GetReaderAtContent();

            String elementName;
            Contact = new Contact();

            if (item.Links.Count > 0)
                Contact.Link = item.Links[0].Uri.ToString();

            while (xmlReader.Read())
            {
                elementName = xmlReader.Name;

                // skip this node if the name is empty
                if (String.IsNullOrEmpty(elementName)) continue;

                if (elementName.Equals("Contact"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        Contact.Id = new Uri(xmlReader.GetAttribute("id"));
                    }
                }
                else if (elementName.Equals("Status"))
                {
                    Contact.Status = (ContactStatus)Enum.Parse(
                        typeof(ContactStatus), xmlReader.ReadString().Replace(' ', '_'));
                }
                else if (elementName.Equals("EmailAddress"))
                {
                    Contact.EmailAddress = xmlReader.ReadString();
                }
                else if (elementName.Equals("EmailType"))
                {
                    Contact.EmailType = (ContactEmailPreference)Enum.Parse(
                        typeof(ContactEmailPreference), xmlReader.ReadString());
                }
                else if (elementName.Equals("Name"))
                {
                    Contact.Name = xmlReader.ReadString();
                }
                else if (elementName.Equals("FirstName"))
                {
                    Contact.FirstName = xmlReader.ReadString();
                }
                else if (elementName.Equals("LastName"))
                {
                    Contact.LastName = xmlReader.ReadString();
                }
                else if (elementName.Equals("JobTitle"))
                {
                    Contact.JobTitle = xmlReader.ReadString();
                }
                else if (elementName.Equals("CompanyName"))
                {
                    Contact.CompanyName = xmlReader.ReadString();
                }
                else if (elementName.Equals("HomePhone"))
                {
                    Contact.HomePhone = xmlReader.ReadString();
                }
                else if (elementName.Equals("WorkPhone"))
                {
                    Contact.WorkPhone = xmlReader.ReadString();
                }
                else if (elementName.Equals("Addr1"))
                {
                    Contact.Addr1 = xmlReader.ReadString();
                }
                else if (elementName.Equals("Addr2"))
                {
                    Contact.Addr2 = xmlReader.ReadString();
                }
                else if (elementName.Equals("Addr3"))
                {
                    Contact.Addr3 = xmlReader.ReadString();
                }
                else if (elementName.Equals("City"))
                {
                    Contact.City = xmlReader.ReadString();
                }
                else if (elementName.Equals("StateCode"))
                {
                    Contact.StateCode = xmlReader.ReadString();
                }
                else if (elementName.Equals("StateName"))
                {
                    Contact.StateName = xmlReader.ReadString();
                }
                else if (elementName.Equals("CountryCode"))
                {
                    Contact.CountryCode = xmlReader.ReadString();
                }
                else if (elementName.Equals("CountryName"))
                {
                    Contact.CountryName = xmlReader.ReadString();
                }
                else if (elementName.Equals("PostalCode"))
                {
                    Contact.PostalCode = xmlReader.ReadString();
                }
                else if (elementName.Equals("SubPostalCode"))
                {
                    Contact.SubPostalCode = xmlReader.ReadString();
                }
                else if (elementName.Equals("Note"))
                {
                    Contact.Note = xmlReader.ReadString();
                }
                else if (elementName.StartsWith("CustomField"))
                {
                    Int32 index = Int32.Parse(elementName.Substring(11));
                    Contact.CustomField[index] = xmlReader.ReadString();
                }
                else if (elementName.Equals("OptInTime"))
                {
                    Contact.OptInTime = DateTimeOffset.Parse(xmlReader.ReadString());
                }
                else if (elementName.Equals("OptInSource"))
                {
                    Contact.OptInSource = (OptInSource)Enum.Parse(
                        typeof(OptInSource), xmlReader.ReadString());
                }
                else if (elementName.Equals("Confirmed"))
                {
                    Contact.Confirmed = Boolean.Parse(xmlReader.ReadString());
                }
                else if (elementName.Equals("InsertTime"))
                {
                    Contact.InsertTime = DateTimeOffset.Parse(xmlReader.ReadString());
                }
                else if (elementName.Equals("LastUpdateTime"))
                {
                    Contact.LastUpdateTime = DateTimeOffset.Parse(xmlReader.ReadString());
                }
                else if (elementName.Equals("ContactList"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        var list = new ContactList(xmlReader.GetAttribute("id"));

                        for (; xmlReader.Name.Equals("ContactList") && !xmlReader.IsStartElement();
                            xmlReader.Read())
                        {
                            if (xmlReader.Name.Equals("OptInSource"))
                            {
                                list.OptInSource = (OptInSource)Enum.Parse(
                                    typeof(OptInSource), xmlReader.ReadString());
                            }
                            else if (xmlReader.Name.Equals("OptInTime"))
                            {
                                list.OptInTime = DateTimeOffset.Parse(xmlReader.ReadString());
                            }
                        }

                        Contact.Lists.Add(list);
                    }
                }
                else
                {
                    Debug.WriteLine(String.Format("Unhandled element: {0}", elementName));
                }
            } // while
        }

        /// <summary>
        /// Initializes a new, default instance of the <see cref="ContactContent"/> class.
        /// </summary>
        private ContactContent()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the syndication content type (application/vnd.ctct+xml).
        /// </summary>
        /// <value></value>
        /// <returns>The name of the type of syndication content.</returns>
        public override string Type
        {
            get { return Constants.ContactContentType; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a copy of the <see cref="T:System.ServiceModel.Syndication.SyndicationContent"/> instance.
        /// </summary>
        /// <returns>
        /// A copy of the <see cref="T:System.ServiceModel.Syndication.SyndicationContent"/> instance.
        /// </returns>
        public override SyndicationContent Clone()
        {
            return (SyndicationContent)MemberwiseClone();
        }

        /// <summary>
        /// Writes the contents of this <see cref="T:System.ServiceModel.Syndication.SyndicationContent"/> object to the specified <see cref="T:System.Xml.XmlWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> to write to.</param>
        protected override void WriteContentsTo(XmlWriter writer)
        {
            writer.WriteStartElement("Contact", Constants.XmlNamespace);
            {
                if (Contact.Id != null)
                {
                    writer.WriteAttributeString("id", Contact.Id.ToString());
                }

                writer.WriteElementStringIfNotNull("EmailAddress", Contact.EmailAddress);
                writer.WriteElementStringIfNotNull("EmailType", Contact.EmailType.ToString());
                writer.WriteElementStringIfNotNull("FirstName", Contact.FirstName);
                writer.WriteElementStringIfNotNull("MiddleName", Contact.MiddleName);
                writer.WriteElementStringIfNotNull("LastName", Contact.LastName);
                writer.WriteElementStringIfNotNull("JobTitle", Contact.JobTitle);

                writer.WriteElementStringIfNotNull("CompanyName", Contact.CompanyName);
                writer.WriteElementStringIfNotNull("HomePhone", Contact.HomePhone);
                writer.WriteElementStringIfNotNull("WorkPhone", Contact.WorkPhone);
                writer.WriteElementStringIfNotNull("Addr1", Contact.Addr1);
                writer.WriteElementStringIfNotNull("Addr2", Contact.Addr2);
                writer.WriteElementStringIfNotNull("Addr3", Contact.Addr3);
                writer.WriteElementStringIfNotNull("City", Contact.City);
                writer.WriteElementStringIfNotNull("StateCode", Contact.StateCode);
                writer.WriteElementStringIfNotNull("StateName", Contact.StateName);
                writer.WriteElementStringIfNotNull("CountryCode", Contact.CountryCode);
                writer.WriteElementStringIfNotNull("CountryName", Contact.CountryName);
                writer.WriteElementStringIfNotNull("PostalCode", Contact.PostalCode);
                writer.WriteElementStringIfNotNull("SubPostalCode", Contact.SubPostalCode);
                writer.WriteElementStringIfNotNull("Note", Contact.Note);

                for (int i = Contact.CustomField.GetLowerBound(0); i <= Contact.CustomField.GetUpperBound(0); i++)
                {
                    writer.WriteElementStringIfNotNull(String.Format("CustomField{0}", i),
                        Contact.CustomField[i]);
                }

                writer.WriteElementString("OptInTime", Contact.OptInTime.ToString("O"));
                writer.WriteElementString("OptInSource", Contact.OptInSource.ToString());
                writer.WriteElementString("Confirmed", Contact.Confirmed.ToString());
                writer.WriteElementString("InsertTime", Contact.InsertTime.ToString("O"));
                writer.WriteElementString("LastUpdateTime", Contact.LastUpdateTime.ToString("O"));

                writer.WriteStartElement("ContactLists");

                foreach (ContactList list in Contact.Lists)
                {
                    writer.WriteStartElement("ContactList");
                    writer.WriteAttributeString("id", list.Link);

                    writer.WriteStartElement("link");
                    writer.WriteAttributeString("href", list.Link);
                    writer.WriteAttributeString("rel", "self");
                    writer.WriteEndElement(); // link

                    writer.WriteElementString("OptInSource", list.OptInSource.ToString());
                    writer.WriteElementString("OptInTime", list.OptInTime.ToString("O"));
                    writer.WriteEndElement(); // ContactList
                }

                writer.WriteEndElement(); // ContactLists
            }
            writer.WriteEndElement(); // Contact
        }

        #endregion Methods
    }
}