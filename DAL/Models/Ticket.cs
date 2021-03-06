﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Ticket : Entity
    {
        [Required]
        public int FlightId { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}