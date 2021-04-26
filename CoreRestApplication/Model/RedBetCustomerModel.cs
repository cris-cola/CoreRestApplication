using Newtonsoft.Json;

namespace CoreRestApplication.Model
{
    public class RedBetCustomerModel : CustomerModel
    {
        public RedBetCustomerModel() { }
        public RedBetCustomerModel(int id, string name, string surname, AddressModel address, string favoriteFootball)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            FavoriteFootballTeam = favoriteFootball;
        }
        
        [JsonProperty(Order = 6)]
        public string FavoriteFootballTeam { get; set; }
    }
}