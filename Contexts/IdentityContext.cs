using FinalSol.Models.Entities;
using FinalSol.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalSol.Contexts;

public class IdentityContext : IdentityDbContext<CustomIdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> UsersInformations { get; set; } = null!;

}
