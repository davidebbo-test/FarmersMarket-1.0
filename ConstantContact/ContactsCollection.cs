using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.ServiceModel.Syndication;
using System.IO;
using System.Diagnostics;

namespace ConstantContact
{
    /// <summary>
    /// The Contacts collection is used to list, create, modify and delete Contacts 
    /// (also known as subscribers) and to associate and disassociate Contacts and Contact Lists.
    /// The Contacts collection resource is designed to be used only with small sets of contacts 
    /// (ie. 24 or less). To manage large groups of contacts, use the Activities API.
    /// </summary>
    public class ContactsCollection
    {
        public static IEnumerable<Contact> GetContacts(ConstantContactCredential credential)
        {
            const String uriFormat = "{0}/ws/customers/{1}/contacts";
            var requestUri = new Uri(String.Format(uriFormat, Constants.ApiEndpoint, credential.CustomerUserName));
            return GetContacts(credential, requestUri);
        }

        public static Contact GetContactByEmail(ConstantContactCredential credential, String email)
        {
            const String uriFormat = "{0}/ws/customers/{1}/contacts?email={2}";
            
            var requestUri = new Uri(String.Format(uriFormat, 
                Constants.ApiEndpoint, credential.CustomerUserName, email));

            IEnumerable<Contact> contacts = GetContacts(credential, requestUri);
            return (contacts.Count() > 0) ? contacts.First() : null;
        }

        public static Contact GetContactByUri(ConstantContactCredential credential, Uri uri)
        {
            return GetContacts(credential, uri).First();
        }

        public static void CreateContact(ConstantContactCredential credential, Contact contact)
        {
            const String uriFormat = "{0}/ws/customers/{1}/contacts";
            var uri = new Uri(String.Format(uriFormat, Constants.ApiEndpoint, credential.CustomerUserName));
            PostContact(credential, uri, contact);
        }

        public static void UpdateContact(ConstantContactCredential credential, Contact contact)
        {
            var uri = new Uri(String.Format("{0}{1}", Constants.ApiEndpoint, contact.Link));
            PutContact(credential, uri, contact);
        }

        public static bool DeleteContact(ConstantContactCredential credential, Contact contact)
        {
            var request = WebRequest.Create(contact.Link) as HttpWebRequest;

            if (request == null)
            {
                throw new WebException("Failed to create WebRequest");
            }

            request.Credentials = credential;
            request.Method = "DELETE";
            request.ContentType = "application/atom+xml"; //  "application/x-www-form-urlencoded";

            // Get response  
            using (var webResponse = request.GetResponse() as HttpWebResponse)
            {
                if (webResponse != null)
                {
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                        throw new WebException(webResponse.StatusDescription);

                    return (webResponse.StatusCode == HttpStatusCode.OK);
                }
            }

            return false;
        }

        protected static IEnumerable<Contact> GetContacts(ConstantContactCredential credential, Uri requestUri)
        {
            var request = WebRequest.Create(requestUri) as HttpWebRequest;

            if (request == null)
            {
                throw new WebException("Failed to create WebRequest");
            }

            request.Credentials = credential;
            request.Method = "GET";
            request.ContentType = "application/atom+xml";

            var contacts = new List<Contact>();

            // Get response  
            using (var webResponse = request.GetResponse() as HttpWebResponse)
            {
                if (webResponse == null)
                {
                    throw new WebException("Failed to create WebRequest");
                }

                // Get the response stream  
                XmlReader xmlReader = XmlReader.Create(webResponse.GetResponseStream());

                if (webResponse.StatusCode != HttpStatusCode.OK)
                    throw new WebException(webResponse.StatusDescription);

                var atomResponse = new Atom10FeedFormatter();

                if (atomResponse.CanRead(xmlReader))
                {
                    atomResponse.ReadFrom(xmlReader);

                    foreach (SyndicationItem item in atomResponse.Feed.Items)
                    {
                        contacts.Add(new ContactContent(item).Contact);
                    }
                }
            }

            return contacts;
        }

        protected static void PostContact(ConstantContactCredential credential, Uri uri, Contact contact)
        {
            var statusCode = SendContact(credential, uri, "POST", contact);

            if (!((statusCode == HttpStatusCode.Created) ||
                (statusCode != HttpStatusCode.OK)))
            { 
                throw new WebException(statusCode.ToString());
            }
        }

        protected static void PutContact(ConstantContactCredential credential, Uri uri, Contact contact)
        {
            var statusCode = SendContact(credential, uri, "PUT", contact);

            if (statusCode != HttpStatusCode.NoContent)
                throw new WebException(statusCode.ToString());
        }

        protected static HttpStatusCode SendContact(
            ConstantContactCredential credential, Uri uri, String method, Contact contact)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;

            if (request == null)
            {
                throw new WebException("Failed to create WebRequest");
            }

            request.Credentials = credential;
            request.Headers.Add("Authorization", String.Format("Basic {0}", 
                Convert.ToBase64String(Encoding.ASCII.GetBytes(credential.Password))));
            request.Method = method;
            request.ContentType = "application/atom+xml"; // "application/x-www-form-urlencoded";

            var contactItem = new SyndicationItem
                                  {
                                      Id = (contact.Id != null) ? contact.Id.ToString() : "data:,none",
                                      Content = new ContactContent(contact)
                                  };

            contactItem.Authors.Add(new SyndicationPerson(typeof(ContactsCollection).FullName));
            contactItem.Summary = new TextSyndicationContent("Contact");

            var atomFormatter = new Atom10ItemFormatter(contactItem);

            using (var memoryStream = new MemoryStream())
            {
                var writerSettings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = " ",
                    OmitXmlDeclaration = true,
                    Encoding = new UTF8Encoding(false),
                };

                var xmlWriter = XmlWriter.Create(memoryStream, writerSettings);

                if (xmlWriter == null)
                    throw new XmlException("Failed to create XmlWriter");

                atomFormatter.WriteTo(xmlWriter);
                xmlWriter.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);
                byte[] data = memoryStream.ToArray();
                memoryStream.Close();

                Debug.WriteLine(Encoding.UTF8.GetString(data));

                // Set the content length in the request headers  
                request.ContentLength = data.Length;

                // Write data  
                using (var postStream = request.GetRequestStream())
                {
                    if (data.Length > int.MaxValue)
                    {
                        throw new InvalidDataException(
                            String.Format("Contact content length exceeds {0} bytes", int.MaxValue));
                    }

                    postStream.Write(data, 0, data.Length);
                }
            }

            // Get response
            using (var webResponse = request.GetResponse() as HttpWebResponse)
            {
                if (webResponse == null)
                {
                    throw new WebException("Failed to get HttpWebResponse");
                }

                // Get the response stream  
                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();
                    Debug.WriteLine(response);
                }

                return webResponse.StatusCode;
            }
        }
    }
}
