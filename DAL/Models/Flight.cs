﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public string Departure { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime DateOfArrival { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
