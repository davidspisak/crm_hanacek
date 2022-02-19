using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class Address
    {
        public int IdAddress { get; set; }
        public string CityName { get; set; }
        public string Zip { get; set; }
        public int? IdCountry { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? IdSubject { get; set; }
        public int? IdAddressType { get; set; }

        public virtual AddressType IdAddressTypeNavigation { get; set; }
        public virtual Country IdCountryNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
