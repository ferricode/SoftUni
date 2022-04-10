using System.ComponentModel.DataAnnotations;

namespace TaxFairy.Core.Models
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Име и Фамилия")]
        public string? FullName { get; set; }


        [Display(Name = "Email адрес")]
        public string Email { get; set; }


    }
}
