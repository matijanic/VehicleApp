using Microsoft.EntityFrameworkCore;
using Project.Common;
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

        
        public async Task<VehicleModelEntity> GetVehicleModelWithVehicleMakeByIdAsync(int Id)
        {
            var entity = await _db.VehicleModels
                 .Include("VehicleMake")
                 .FirstOrDefaultAsync(a => a.Id == Id);

            return entity;
        }

        public async Task<List<VehicleModelEntity>> GetFilteredAsync(QueryParameters parameters)
        {
            var list = _db.VehicleModels.AsQueryable();

            //filtering

            if(!string.IsNullOrWhiteSpace(parameters.FilterByName))
            {
                list = list.Where(x=>x.Name.Contains(parameters.FilterByName));
            }


            //sorting

            if(!string.IsNullOrWhiteSpace(parameters.SortBy))
            {
                
                if(parameters.SortBy.Contains("Name", StringComparison.OrdinalIgnoreCase))
                {
                    list = parameters.IsAscending.HasValue ?
                        (parameters.IsAscending.Value ? list.OrderBy(x => x.Name) : list.OrderByDescending(x => x.Name)) :
                        list;
                }
            }

            //pagination

            var skipResults = (parameters.PageNumber-1) * parameters.PageSize;
            
            return await list.Skip(skipResults).Take(parameters.PageSize).ToListAsync();
        }

        

       
    }
}
