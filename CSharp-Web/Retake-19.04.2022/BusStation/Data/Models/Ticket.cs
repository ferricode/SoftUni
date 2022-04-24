﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(10,90)]
        public decimal Price { get; set; }

        public string UserId { get; set; }
       
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; }


    }
}
