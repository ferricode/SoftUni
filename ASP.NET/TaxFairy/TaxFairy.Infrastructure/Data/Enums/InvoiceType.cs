using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data.Enums
{
    public enum InvoiceType
    {
        [Description("Фактура")]
        Invoice,
        [Description("Кредитно Известие")]
        CreditNote,
        [Description("Дебитно Известие")]
        DebitNote,
    }
}
