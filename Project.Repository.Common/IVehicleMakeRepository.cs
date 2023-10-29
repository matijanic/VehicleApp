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
        Task<VehicleMakeEntity> GetWithModelsByIdAsync(int Id);

    }

  

}
