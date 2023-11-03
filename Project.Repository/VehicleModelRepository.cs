using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository.Common;

namespace Project.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModelEntity>, IVehicleModelRepository
    {
        public VehicleModelRepository(VehicleDbContext db) : base(db)
        {

        }


        public async Task<List<VehicleModelEntity>> GetAllWithVehicleMakes()
        {
            var listAll = await _db.VehicleModels
                .Include(a=> a.VehicleMake)
                .ToListAsync();

            return listAll;
        }

        public async Task<VehicleModelEntity> GetVehicleModelWithVehicleMakeById(int Id)
        {
           var entity = await _db.VehicleModels
                .Include(a=> a.VehicleMake)
                .FirstOrDefaultAsync (a=> a.Id == Id);
           
            return entity;
        }
    }
}
