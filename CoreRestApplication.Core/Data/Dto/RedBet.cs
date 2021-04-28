using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Core.Data
{
    public class RedBet : CustomerDto
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
        public RedBet(int id, string name, string surname, AddressDto address, string favoriteFootballTeam) : base(id, name, surname, address)
        {
            FavoriteFootballTeam = favoriteFootballTeam;
        }
    }
}