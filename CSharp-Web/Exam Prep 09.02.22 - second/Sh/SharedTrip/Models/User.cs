﻿using SharedTrip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTrip.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        public ICollection<UserTrip> UserTrips { get; set; }
        public User()
        {
            Id=Guid.NewGuid().ToString();
            UserTrips = new List<UserTrip>();
        }
    }
}