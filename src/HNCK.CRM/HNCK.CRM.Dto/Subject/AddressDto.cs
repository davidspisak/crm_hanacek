using HNCK.CRM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Dto.Subject
{
	public class AddressDto
	{
        public int IdAddress { get; set; }
        public string CityName { get; set; }
        public string Zip { get; set; }
        public int? IdCountry { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? IdAddressType { get; set; }
        public string CountryNameENShort { get; set; }
    }
}
