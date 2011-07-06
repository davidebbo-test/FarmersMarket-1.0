using System;
using System.Xml;

namespace ConstantContact
{
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Converts the specified DateTime to its relative date.
        /// </summary>
        /// <returns>A string value based on the relative date
        /// of the datetime as compared to the current date.</returns>
        public static void WriteElementStringIfNotNull(this XmlWriter writer, String localName, String value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteElementString(localName, value);
            }
        }
    }
}
