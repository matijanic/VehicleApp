using Project.Common;
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

        Task<List<VehicleMakeEntity>> GetFilteredAsync(QueryParameters parameters);
        
    }

  

}
