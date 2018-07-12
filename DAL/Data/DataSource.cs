using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Data
{
    public class DataSource : IDataSource
    {
        public List<Airport> GetAirports()
        {
            var list = new List<Airport>
            {
                new Airport {Id = 1, Name = "Heathrow", City = "London", Country = "UK"},
                new Airport {Id = 2, Name = "Boryspil International Airport", City = "Boryspil", Country = "Ukraine"},
                new Airport {Id = 3, Name = "Madrid–Barajas Airport", City = "Madrid", Country = "Spain"}
            };

            return list;
        }
    }
}