using System.ComponentModel.DataAnnotations;


namespace TaxFairy.Core.ViewModels
{
    public class NewsCreateViewModel
    {

        [StringLength(10000, MinimumLength = 0, ErrorMessage = "Съдържанието трябва да бъде по-малко от {1} символа")]
        public string Content { get; set; }

    }
}
