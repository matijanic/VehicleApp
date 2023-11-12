using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMakeEntity>
    {
        Task<List<VehicleMakeEntity>> GetAllDetailsWithModelsAsync();
        Task<VehicleMakeEntity> GetVehicleMakeWithModelById(int Id);

        Task <List<VehicleMakeEntity>> GetFilterByNameAsync(string? Name = null);

        Task<List<VehicleMakeEntity>> GetSortByNameAsync(string? Name = null, bool isAscending = true);

        Task<List<VehicleMakeEntity>> PagingVehicleMakesAsync(int pageNumber= 1, int pageSize = 1000);

    }

  

}
