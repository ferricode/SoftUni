using System.ComponentModel.DataAnnotations;

namespace Warehouse.Core.CustomAttributes
{
    public class IsBeforeAttribute : ValidationAttribute
    {
        private readonly string _propertyToCompare;
        public IsBeforeAttribute(string _propertyToCompare, string errorMessage = "")
        {
            this._propertyToCompare = _propertyToCompare;
            this.ErrorMessage = errorMessage;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
          


            try
            {
                DateTime dateToCompare = (DateTime)validationContext
               .ObjectType
               .GetProperty(_propertyToCompare)
               .GetValue(validationContext.ObjectInstance);

                if ((DateTime)value < dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            catch (Exception ex)
            {}

            return new ValidationResult(ErrorMessage);
        }

   
    }
}
