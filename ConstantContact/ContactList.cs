using System;

namespace ConstantContact
{
    public class ContactList
    {
        public ContactList()
        {
            OptInTime = DateTimeOffset.Now;
        }

        public ContactList(String link) : this()
        {
            Link = link;
        }

        public string Link { get; internal set; }

        public OptInSource OptInSource { get; set; }
        public DateTimeOffset OptInTime { get; set; }
    }
}
