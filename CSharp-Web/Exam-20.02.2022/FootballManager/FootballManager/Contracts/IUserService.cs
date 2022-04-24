using FootballManager.Models;
using FootballManager.Models.Users;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateRegisterModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model);

        string GetUsername(string userId);

    }
}
