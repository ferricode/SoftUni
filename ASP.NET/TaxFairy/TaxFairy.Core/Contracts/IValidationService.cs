using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Core.Contracts
{
    public interface IValidationService
    {
        public interface IValidationService
        {
            (bool isValid, string error) ValidateModel(object model);
        }
    }
}
