using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Data
{
    public class CustomerDto : IValidatableObject
    {
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
        public string PersonalNumber { get; set; }
        public string FavoriteFootballTeam { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == 0)
            {
                yield return new ValidationResult($"{nameof(Id)} field is mandatory and must be greater than 0", new[] { nameof(Id) });
            }
            if (string.IsNullOrEmpty(CustomerType))
            {
                yield return new ValidationResult($"{nameof(CustomerType)} field must be provided. Accepted values: 'RedBet', 'MrGreen'", new[] { nameof(CustomerType) });
            }
            if (CustomerType != null && !CustomerType.Equals(CustomerTypes.RedBet) && !CustomerType.Equals(CustomerTypes.MrGreen))
            {
                yield return new ValidationResult($"{nameof(CustomerType)} field not inserted correctly. Accepted values: 'RedBet', 'MrGreen'", new[] { nameof(CustomerType) });
            }

            if (CustomerType == CustomerTypes.RedBet && string.IsNullOrEmpty(FavoriteFootballTeam))
            {
                yield return new ValidationResult($"The {nameof(FavoriteFootballTeam)} field must be provided.", new[] { nameof(FavoriteFootballTeam) });
            }
            if (CustomerType == CustomerTypes.MrGreen && string.IsNullOrEmpty(PersonalNumber))
            {
                yield return new ValidationResult($"The {nameof(PersonalNumber)} field must be provided.", new[] { nameof(PersonalNumber) });
            }
        }
    }

    public struct CustomerTypes
    {
        public const string RedBet = "RedBet";
        public const string MrGreen = "MrGreen";
    }
}
