using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public interface IAddress
	{
        int IdAddress { get; set; }
        string CityName { get; set; }
        string Zip { get; set; }
        int? IdCountry { get; set; }
        string StreetName { get; set; }
        string StreetNumber { get; set; }
        DateTime? ValidTo { get; set; }
        int? IdAddressType { get; set; }
    }
}
