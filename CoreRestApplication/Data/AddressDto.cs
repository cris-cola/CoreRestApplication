using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Data
{
    public class AddressDto
    {
        public AddressDto() { }
        public AddressDto(string streetName, string streetNumber, string zipCode)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ZipCode = zipCode;
        }
       
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}