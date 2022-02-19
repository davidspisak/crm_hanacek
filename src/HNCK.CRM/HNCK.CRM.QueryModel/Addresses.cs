using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.QueryModel
{
	public class Addresses
	{
		public int IdAddress { get; set; }
		public string CityName { get; set; }
		public string Zip { get; set; }
		public string StreetName { get; set; }
		public string StreetNumber { get; set; }
		public DateTime? ValidTo { get; set; }
		public int IdSubject { get; set; }
		public string AddressTypeDescription { get; set; }
		public string CountryAkronym2 { get; set; }
		public string CountryAkronym3 { get; set; }
		public string CountryNameEN { get; set; }
		public string CountryNameENShort { get; set; }
		public string CountryNameSK { get; set; }
		public string CountryNameSKShort { get; set; }
		public int IdAddressType { get; set; }
		public int IdCountry { get; set; }
	}
}
