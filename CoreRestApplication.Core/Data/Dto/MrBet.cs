using System.ComponentModel.DataAnnotations;

namespace CoreRestApplication.Core.Data.Dto
{
    public class MrBet : CustomerDto
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
        public MrBet(int id, string name, string surname, AddressDto address, string favoriteFootballTeam) : base(id, name, surname, address)
        {
            FavoriteFootballTeam = favoriteFootballTeam;
        }
    }
}