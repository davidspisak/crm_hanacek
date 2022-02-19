using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Dto.Event
{
	public class UserEventDto
	{
        public int IdUserEvent { get; set; }
        public string Name { get; set; }
        public string Decsription { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? NotificationDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? IdSubject { get; set; }
    }
}
