using HNCK.CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public interface ISubject
	{
        int IdSubject { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string TelNumber { get; set; }
        string PersonalIdentificationNumber { get; set; }
        string BusinessIdentificationNumber { get; set; }
        DateTime? BirthDate { get; set; }
        DateTime? ResidenceCardValidTo { get; set; }
        string Note { get; set; }
        IEnumerable<Address> Addresses { get; set; }
    }
}
