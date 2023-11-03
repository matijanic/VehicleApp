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

        Task<VehicleModelEntity> GetVModelWithVMakeById(int id);
    }
}