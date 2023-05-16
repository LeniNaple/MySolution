using FinalSol.Models.Entities;
using FinalSol.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalSol.Contexts { 

    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AdressEntity> AspNetAdresses { get; set; } 
        public DbSet<UserAdressEntity> AspNetUsersAdresses { get; set; } 


    }
}