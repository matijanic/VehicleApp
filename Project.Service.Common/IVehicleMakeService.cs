using Project.Common;
using Project.DAL;
using Project.Model;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {


        Task<VehicleMakeModel> GetVMakeById(int id);

        Task CreateVMake(VehicleMakeModel entity);

        Task UpdateVMake(int id, VehicleMakeModel entity);

        Task <bool>DeleteVMake(int id);

        Task<List<VehicleMakeModel>> GetFiltered(QueryParameters parameters);

        

       

        
        
    }
}