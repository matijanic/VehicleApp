using Project.DAL;
using Project.Model;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelModel>> GetAllVModels();

        Task<VehicleModelModel> GetVModelById(int id);

        Task CreateVModel(VehicleModelModel entity);

        Task UpdateVModel(int id, VehicleModelModel entity);

        Task<bool> DeleteVModel(int id);

        Task<List<VehicleModelEntity>> GetAllWithVMakes();

        Task<VehicleModelModel> GetVModelWithVMakeById(int id);

        Task <List<VehicleModelModel>> GetFilterByName(string? Name = null);

        Task<List<VehicleModelModel>> GetSortByName(string? Name = null, bool isAscending = true);

        Task<List<VehicleModelModel>> PagingVehicleModels(int pageNumber = 1, int pageSize = 1000);
    }
}