﻿using System;

namespace Shared.DTOs
{
    public class PlaneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaneTypeDTO PlaneType { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Lifetime { get; set; }
    }
}