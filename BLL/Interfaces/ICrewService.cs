using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.DTOs;

namespace BLL.Interfaces
{
    public interface ICrewService : IService<CrewDTO>
    { 
        Task<List<CrewDTO>> LoadTenCrews();
    }
}