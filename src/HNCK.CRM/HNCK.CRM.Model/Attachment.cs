using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class Attachment
    {
        public Guid IdAttachment { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public decimal Size { get; set; }
        public string RelativePath { get; set; }
        public string ContentType { get; set; }
        public int? IdSubject { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
