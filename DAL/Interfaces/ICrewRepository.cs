using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ICrewRepository : IRepository<Crew>
    {
        Task CreateRange(List<Crew> entity);
    }
}