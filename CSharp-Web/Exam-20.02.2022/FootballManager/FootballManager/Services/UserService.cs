using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Models;
using FootballManager.Models.Users;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }
        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = GetUserByUsername(model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException("Registration failed");
            }
            else
            {
                User user = new User()
                {
                    Email = model.Email,
                    Username = model.Username
                };

                user.Password = HashPassword(model.Password);

                try
                {
                    repo.Add(user);
                    repo.SaveChanges();
                }
                catch (Exception)
                {

                    throw new ArgumentException("Could not save user to DB");
                }

            }
        }

        private User? GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateRegisterModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null ||
               model.Username.Length < 5 ||
               model.Username.Length > 20)
            {

                isValid = false;
                errors.Add(new ErrorViewModel("Username is requred and must be between 5 and 20 characters"));
            }

            if (string.IsNullOrWhiteSpace(model.Email) ||
                 model.Email.Length < 10 ||
                model.Email.Length > 60)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password == null ||
                model.Password.Length < 5 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is requred and must be between 6 and 20 characters"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and ConfirmPassword are not the same"));
            }

            return (isValid, errors);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }

        public string GetUsername(string userId)
        {
#pragma warning disable CS8603 // Possible null reference return.

            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;

#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
