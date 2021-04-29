using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Core.Data.Dto
{
    public class MrGreen : CustomerDto
    {
        [Required]
        public string PersonalNumber{ get; set; }
        public MrGreen(int id, string name, string surname, AddressDto address, string personalNumber) : base(id, name, surname, address)
        {
            PersonalNumber = personalNumber;
        }
    }
}