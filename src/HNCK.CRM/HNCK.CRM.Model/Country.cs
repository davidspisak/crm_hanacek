using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Subjects = new HashSet<Subject>();
        }

        public int IdCountry { get; set; }
        public string Code { get; set; }
        public string Acronym2 { get; set; }
        public string Acronym3 { get; set; }
        public string NameSkshort { get; set; }
        public string NameSk { get; set; }
        public string NameEn { get; set; }
        public string NameEnshort { get; set; }
        public bool? IsValid { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
