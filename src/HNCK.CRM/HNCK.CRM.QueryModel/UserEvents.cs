using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.QueryModel
{
	public class UserEvents
	{
		public int IdUserEvent { get; set; }
		public string Name { get; set; }
		public string Decsription { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? NotificationDate { get; set; }
		public DateTime? TerminationDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public int? IdSubject { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime? ValidTo { get; set; }
		public string Email { get; set; }
		public string TelNumber { get; set; }
		public string PersonalIdentificationNumber { get; set; }
		public string BusinessIdentificationNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? ResidenceCardValidTo { get; set; }
		public string Subject_FullName { get; set; }
	}
}
