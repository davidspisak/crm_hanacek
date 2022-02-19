using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class AddressType
    {
        public AddressType()
        {
            Addresses = new HashSet<Address>();
        }

        public int IdAddressType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? ValitdTo { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
