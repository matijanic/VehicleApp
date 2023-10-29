using Project.DAL;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModelEntity>
    {
        Task<List<VehicleModelEntity>> GetAllWithVehicleMakes();
        Task<VehicleModelEntity> GetWithVehicleMakeById(int Id);
    }

  

}
