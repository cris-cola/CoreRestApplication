using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Core.Data
{
    public class CustomerDto
    {
        public CustomerDto() { }
        public CustomerDto(int id, string name, string surname, AddressDto address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; }
        [Required]
        public string Surname { get; }
        [Required]
        public AddressDto Address { get; }
        
        public string CustomerType { get; set; }
    }
}
