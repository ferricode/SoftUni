using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels
{
    public class DestinationListViewModel
    {


      
        [StringLength(50, MinimumLength = 2)]
        public string DestinationName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Origin { get; set; }
        
        [StringLength(30)]
        public string Date { get; set; }

        [StringLength(30)]
        public string Time { get; set; }

        public string ImageUrl { get; set; }
        public int TicketsCount { get; set; }

        //•	Has Date – a string with max length 30 (required). We recommend using "d" as a date format.The date cannot be smaller than the date of the creation of the destination.
        //•	Has Time – a string with max length 30 (required). We recommend using "t" as a time format.

    }
}
