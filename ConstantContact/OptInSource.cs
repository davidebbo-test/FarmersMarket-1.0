using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstantContact
{
    /// <summary>
    /// The source of the opt-in
    /// </summary>
    public enum OptInSource
    {
        /// <summary>
        /// Opt in by the Constant Contact customer
        /// </summary>
        ACTION_BY_CUSTOMER,
        /// <summary>
        /// Opt in by explicit contact action
        /// </summary>
        ACTION_BY_CONTACT,
    }
}
