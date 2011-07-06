namespace ConstantContact
{
    using System;
    using System.Net;

    /// <summary>
    /// Encapsulates a set of credentials to pass to the Constant Contact web services.
    /// The username is a concatenation of your API key and username delimited by a '%'.
    /// </summary>
    public class ConstantContactCredential : NetworkCredential
    {
        #region Fields

        private const String UserNameFormat = "{0}%{1}"; // API Key, user name

        #endregion Fields

        #region Constructors

        public ConstantContactCredential(String apiKey, String userName, String password)
            : base(String.Format(UserNameFormat, apiKey, userName), password)
        {
            CustomerUserName = userName;
        }

        #endregion Constructors

        #region Properties

        public String CustomerUserName
        {
            get; set;
        }

        #endregion Properties
    }
}