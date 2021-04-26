using Newtonsoft.Json;

namespace CoreRestApplication.Model
{
    public class MrGreenCustomerModel : CustomerModel
    {
        public MrGreenCustomerModel() { }
        public MrGreenCustomerModel(int id, string name, string surname, AddressModel address, string personalNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            PersonalNumber = personalNumber;
        }
        
        [JsonProperty(Order = 6)]
        public string PersonalNumber { get; set; }
    }
}