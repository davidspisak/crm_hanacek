using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.QueryModel
{
	public class Attachments
	{
        public Guid IdAttachment { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public decimal Size { get; set; }
        public string RelativePath { get; set; }
        public string ContentType { get; set; }
        public int? IdSubject { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
