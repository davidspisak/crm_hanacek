namespace HNCK.CRM.Model
{
	public class Address
	{
		public int IdAddress { get; set; }
		public string CityName { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string StreetName { get; set; }
		public string StreetNumber { get; set; }
		public bool IsValid { get; set; } = true;
		public AddressTypeEnum AddressType { get; set; }

	}

	public enum AddressTypeEnum
	{
		PermanentResidence,
		Correspondence,
		RegisteredOffice
	}
}