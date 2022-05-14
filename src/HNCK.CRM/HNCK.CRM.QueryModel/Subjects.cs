using System;

namespace HNCK.CRM.QueryModel
{
	public class Subjects
	{
		public int IdSubject { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string TelNumber { get; set; }
		public string PersonalIdentificationNumber { get; set; }
		public string BusinessIdentificationNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? ResidenceCardValidTo { get; set; }
		public string Note { get; set; }
		public DateTime? ValidTo { get; set; }
		public string FullAddress { get; set; }
		public string TravelDocument { get; set; }
		public int? IdNationality { get; set; }
		public string Nationality { get; set; }
	}
}
