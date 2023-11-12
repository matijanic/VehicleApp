using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMakeEntity>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(VehicleDbContext db) : base(db)
        {

        }

        public async Task<List<VehicleMakeEntity>> GetAllDetailsWithModelsAsync()
        {
            var allList = await _db.VehicleMakes
                .Include("Models") 
                .ToListAsync();

            return allList;
        }

        public async Task<List<VehicleMakeEntity>> GetFilterByNameAsync(string? Name = null)
        {
            var list = _db.VehicleMakes
                .Include("Models").AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                list =  list.Where(x=>x.Name.Contains(Name));
            }

            return await list.ToListAsync();
        }

        public async Task<List<VehicleMakeEntity>> GetSortByNameAsync(string? Name = null, bool isAscending = true)
        {

            var list = _db.VehicleMakes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))

                if (Name.Equals("Name", StringComparison.OrdinalIgnoreCase)) 
                {
                    list = isAscending ? list.OrderBy(x => x.Name) : list.OrderByDescending(x => x.Name);
                }
            
            

            return await list.ToListAsync();
        }

        public async Task<VehicleMakeEntity> GetVehicleMakeWithModelById(int Id)
        {
            var entity = await _db.VehicleMakes
                .Include("Models")
                .FirstOrDefaultAsync(a=> a.Id == Id);

            return entity;
        }

        public async Task<List<VehicleMakeEntity>> PagingVehicleMakesAsync(int pageNumber = 1, int pageSize = 1000)
        {
            var list = _db.VehicleMakes.AsQueryable();

            var skipResults = (pageNumber -1) * pageSize;

            return await list.Skip(skipResults).Take(pageSize).ToListAsync();


        }
    }
}
