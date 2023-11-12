using Project.DAL;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModelEntity>
    {
       
        Task<List<VehicleModelEntity>> GetAllWithVehicleMakes();
        Task<VehicleModelEntity> GetVehicleModelWithVehicleMakeByIdAsync(int Id);

        Task <List<VehicleModelEntity>> GetFilterByNameAsync(string? Name = null);

        Task<List<VehicleModelEntity>> GetSortByNameAsync(string? Name = null, bool isAscending = true);

        Task<List<VehicleModelEntity>> PagingVehicleModels(int pageNumber = 1, int pageSize = 1000);
    }

  

}
