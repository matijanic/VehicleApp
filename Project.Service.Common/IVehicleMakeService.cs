using Project.DAL;
using Project.Model;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {

        Task<List<VehicleMakeModel>> GetAllVMakes();

        Task<VehicleMakeModel> GetVMakeById(int id);

        Task CreateVMake(VehicleMakeModel entity);

        Task UpdateVMake(int id, VehicleMakeModel entity);

        Task <bool>DeleteVMake(int id);

        Task<List<VehicleMakeModel>> GetAllWithModels();

        Task <VehicleMakeModel> GetVMakeWithModelsById(int id);

        Task<List<VehicleMakeModel>> GetFilterByName(string? Name = null);

        Task<List<VehicleMakeModel>> GetSortByName(string? Name = null, bool isAscending = true);

        Task<List<VehicleMakeModel>> PagingVehicleMakes(int pageNumber = 1, int pageSize=1000);

        //Task<VehicleModelEntity> Exists(int id);

       

        
        
    }
}