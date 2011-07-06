namespace ConstantContact
{
    /// <summary>
    /// Describes current status of the Contact
    /// </summary>
    public enum ContactStatus
    {
        /// <summary>
        /// Contact is active and may be contacted
        /// </summary>
        Active,
        /// <summary>
        /// Contact has not yet confirmed eligibility
        /// </summary>
        Unconfirmed,
        /// <summary>
        /// Contact has requested removal
        /// </summary>
        Removed,
        /// <summary>
        /// Contact may not be contacted under any circumstances
        /// </summary>
        Do_Not_Mail,
    }
}
