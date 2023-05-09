using FinalSol.Models.Identity;
using System.Linq.Expressions;

namespace FinalSol.Repositories;

public class UserRepository
{
    public async Task<bool> AnyAsync(Expression<Func<CustomIdentityUser, bool>> predicate)
    {
        return false;
    }

    public async Task<bool> CreateAsync()
    {
        return false;
    }

    public async Task<bool> CreateProfileAsync()
    {
        return false;
    }



}
