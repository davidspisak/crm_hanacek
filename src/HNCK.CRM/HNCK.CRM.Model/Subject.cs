using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class Subject
    {
        public Subject()
        {
            Addresses = new HashSet<Address>();
            Attachment1s = new HashSet<Attachment>();
            UserEvents = new HashSet<UserEvent>();
        }

        public int IdSubject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string BusinessIdentificationNumber { get; set; }
        public string TravelDocument { get; set; }
        public int? IdNationality { get; set; }
        public virtual Country IdNationalityNavigation { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? ResidenceCardValidTo { get; set; }
        public string Note { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Attachment> Attachment1s { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
