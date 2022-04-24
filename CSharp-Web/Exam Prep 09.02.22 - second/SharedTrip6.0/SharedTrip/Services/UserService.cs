using SharedTrip.Contracts;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
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
            var userExits = GetUserByUserName(model.Username)!=null;
            if (userExits)
            {
                throw new ArgumentException("Registration failed");
            }

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username
            };

            user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();

        }

        private User GetUserByUserName(string username)
        { 
        return repo.All<User>()
                 .FirstOrDefault(u => u.Username == username);
        }
        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(passwordArray).ToString();
                // return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }


        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is required and must be between 5 and 20!"));
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required!"));
            }
            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is required and mus tbe between 6 and 20!"));
            }
            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and ConfirmPassword must be the same!"));
            }
            return (isValid, errors);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUserName(model.Username);

            if (user!=null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }
            return (userId, isCorrect);
        }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has UserTrips collection – a UserTrip type
