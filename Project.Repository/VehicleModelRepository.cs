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
                .Include("VehicleMake")
                .ToListAsync();

            return listAll;
        }

        public async Task<List<VehicleModelEntity>> GetFilterByNameAsync(string? Name = null)
        {

            var list = _db.VehicleModels.
                Include("VehicleMake").AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                list = list.Where(x => x.Name.Contains(Name));
            }

            return await list.ToListAsync();



        }

        public async Task<List<VehicleModelEntity>> GetSortByNameAsync(string? Name = null, bool isAscending = true)
        {
            var list = _db.VehicleModels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                if (Name.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    list = isAscending ? list.OrderBy(x => x.Name)
                        : list.OrderByDescending(x => x.Name);
                }

            }
            return await list.ToListAsync();
        }

        public async Task<VehicleModelEntity> GetVehicleModelWithVehicleMakeByIdAsync(int Id)
        {
            var entity = await _db.VehicleModels
                 .Include("VehicleMake")
                 .FirstOrDefaultAsync(a => a.Id == Id);

            return entity;
        }

        public async Task<List<VehicleModelEntity>> PagingVehicleModels(int pageNumber = 1, int pageSize = 1000)
        {

            var list = _db.VehicleModels.AsQueryable();

            var skipResults = (pageNumber - 1) * pageSize;

            return await list.Skip(skipResults).Take(pageSize).ToListAsync();
        }
    }
}
