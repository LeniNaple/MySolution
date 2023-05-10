using FinalSol.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalSol.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid UserId { get; set; } 

        public string? StreetName { get; set; }

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public string? CompanyName { get; set; }

        public string? ProfileImageUrl { get; set; }

        public ICollection<CustomIdentityUser> Customers = new HashSet<CustomIdentityUser>();

    }
}
