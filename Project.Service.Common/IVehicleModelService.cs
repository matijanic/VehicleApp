using Project.Common;
using Project.DAL;
using Project.Model;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
       

        Task<VehicleModelModel> GetVModelById(int id);

        Task CreateVModel(VehicleModelModel entity);

        Task UpdateVModel(int id, VehicleModelModel entity);

        Task<bool> DeleteVModel(int id);

       

        Task<List<VehicleModelModel>> GetFiltered(QueryParameters parameters);
    }
}