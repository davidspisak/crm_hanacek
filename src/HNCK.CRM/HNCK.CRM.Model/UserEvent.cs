using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class UserEvent
    {
        public int IdUserEvent { get; set; }
        public string Name { get; set; }
        public string Decsription { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? NotificationDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? IdSubject { get; set; }

        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
