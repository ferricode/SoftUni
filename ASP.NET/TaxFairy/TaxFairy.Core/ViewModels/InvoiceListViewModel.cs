﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Infrastructure.Data.Enums;
using TaxFairy.Infrastructure.Data.Models;

namespace TaxFairy.Core.ViewModels
{
    public class InvoiceListViewModel
    {
        public string Id { get; set; }
        public long InvoiceNumber { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string ContragentName { get; set; }

    }
}