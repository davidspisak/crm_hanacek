using System;
using System.Collections.Generic;

namespace HNCK.CRM.Model
{
	public class Subject
	{
		public int IdSubject { get; set; }
		public string FistName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }
		public string Note { get; set; }
		public IEnumerable<Address> Address { get; set; }
	}
}
