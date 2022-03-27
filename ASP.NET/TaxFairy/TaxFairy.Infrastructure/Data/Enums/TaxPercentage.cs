using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data.Enums
{
    public enum TaxPercentage
    {
        [Description("0%")]
        _0,
        [Description("9%")]
        _9,
        [Description("20%")]
        _20

    }
}
