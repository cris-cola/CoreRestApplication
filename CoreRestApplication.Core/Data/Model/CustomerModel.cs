using CoreRestApplication.Core.Data.Dto;

namespace CoreRestApplication.Core.Data.Model
{
    public class CustomerModel
    {
        public CustomerModel(int id, string name, string surname, AddressDto address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
        }
        
        public int Id { get; set; }
        
        public string Name { get; }
        public string Surname { get; }
        
        public AddressDto Address { get; }

        public string CustomerType { get; set; }
    }

    public class RedBetModel : CustomerModel
    {
        public string FavoriteFootballTeam { get; set; }

        public RedBetModel(int id, string name, string surname, AddressDto address) : base(id, name, surname, address)
        {
        }
    }

    public class MrGreenModel : CustomerModel
    {
        public string PersonalNumber { get; set; }

        public MrGreenModel(int id, string name, string surname, AddressDto address, string personalNumber) : base(id, name, surname, address)
        {
            PersonalNumber = personalNumber;
        }
    }
}
