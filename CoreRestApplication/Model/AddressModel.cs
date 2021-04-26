namespace CoreRestApplication.Model
{
    public class AddressModel
    {
        public AddressModel() { }
        public AddressModel(string streetName, string streetNumber, string zipCode)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ZipCode = zipCode;
        }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
    }
}