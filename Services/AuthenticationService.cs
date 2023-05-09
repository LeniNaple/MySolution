using FinalSol.Repositories;
using FinalSol.ViewModels;

namespace FinalSol.Services;

public class AuthenticationService
{
    private readonly UserRepository _userRepository;

    public AuthenticationService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }



    public async Task<bool> RegisterAsync(UserRegistrationViewModel viewModel)
    {
        if (!await _userRepository.AnyAsync(x => x.Email == viewModel.Email))
        {
            await _userRepository.CreateAsync(viewModel);
            await _userRepository.CreateProfileAsync(viewModel);

            return true;
        }


        return false;
    }

}
