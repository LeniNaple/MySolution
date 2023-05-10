using FinalSol.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalSol.Models.Identity
{
    public class CustomIdentityUser : IdentityUser
    {

        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;


        public Guid AdressId { get; set; } 
    }
}
