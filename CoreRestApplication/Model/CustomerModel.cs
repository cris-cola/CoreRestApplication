namespace CoreRestApplication.Model
{
    public class MrGreenCustomerModel : ICustomerModel
    {
        public MrGreenCustomerModel()
        {
        }
        public MrGreenCustomerModel(int id, string name, string surname, AddressModel address, string personalNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            PersonalNumber = personalNumber;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressModel Address { get; set; }
        public string CustomerType { get; set; }

        public string PersonalNumber { get; set; }
    }


    public class RedBetCustomerModel : ICustomerModel
    {
        public RedBetCustomerModel()
        {
        }
        public RedBetCustomerModel(int id, string name, string surname, AddressModel address, string favoriteFootball)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            FavoriteFootballTeam = favoriteFootball;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressModel Address { get; set; }
        public string CustomerType { get; set; }

        public string FavoriteFootballTeam { get; set; }

    }

    public class AddressModel
    {
        public AddressModel()
        {
        }
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
