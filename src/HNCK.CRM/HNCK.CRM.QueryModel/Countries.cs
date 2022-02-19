using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.QueryModel
{
	public class Countries
	{
		public int IdCountry { get; set; }
		public string Code { get; set; }
		public string Acronym2 { get; set; }
		public string Acronym3 { get; set; }
		public string NameSKShort { get; set; }
		public string NameSK { get; set; }
		public string NameEN { get; set; }
		public string NameENShort { get; set; }
		public bool? IsValid { get; set; }
	}
}
