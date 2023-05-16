using FinalSol.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalSol.Models.Identity
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string? ProfileImageUrl { get; set; }

        public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();

    }
}
