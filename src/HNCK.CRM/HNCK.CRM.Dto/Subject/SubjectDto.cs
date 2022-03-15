using HNCK.CRM.Dto.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Dto.Subject
{
	public class SubjectDto
	{
		public int? IdSubject { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string TelNumber { get; set; }
		public string FullName => string.Concat(LastName, " ", FirstName);
		public string PersonalIdentificationNumber { get; set; }
		public string BusinessIdentificationNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? ResidenceCardValidTo { get; set; }
		public AddressDto Address { get; set; }
		public string FullAddress { get; set; }
		public string Note { get; set; }
		public IEnumerable<UserEventDto>? UserEvents { get; set; }
	}
}
