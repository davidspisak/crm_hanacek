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
		public string FullAddress { get; set; } = "Mostná 16, 955 01 Topoľčany, Slovenská republika";
	}
}
