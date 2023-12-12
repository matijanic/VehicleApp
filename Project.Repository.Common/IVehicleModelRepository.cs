using Project.Common;
using Project.DAL;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModelEntity>
    {
       
        Task<List<VehicleModelEntity>> GetAllWithVehicleMakes();
        Task<VehicleModelEntity> GetVehicleModelWithVehicleMakeByIdAsync(int Id);

        Task<List<VehicleModelEntity>> GetFilteredAsync(QueryParameters parameters);
    }

  

}
