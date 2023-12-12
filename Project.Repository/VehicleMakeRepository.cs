using Microsoft.EntityFrameworkCore;
using Project.Common;
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


        public async Task<VehicleMakeEntity> GetVehicleMakeWithModelById(int Id)
        {
            var entity = await _db.VehicleMakes
                .Include("Models")
                .FirstOrDefaultAsync(a=> a.Id == Id);

            return entity;
        }

        public async Task<List<VehicleMakeEntity>> GetFilteredAsync(QueryParameters parameters)
        {
            var list = _db.VehicleMakes.AsQueryable();


            //filtering
            if (!string.IsNullOrWhiteSpace(parameters.FilterByName))
            {
               list=list.Where(x=>x.Name.Contains(parameters.FilterByName));
            }

            //sorting

            if (!string.IsNullOrEmpty(parameters.SortBy))
            {
                if(parameters.SortBy.Contains("Name", StringComparison.OrdinalIgnoreCase))
                {
                    list = parameters.IsAscending.HasValue ?
                        (parameters.IsAscending.Value ? list.OrderBy(x => x.Name) : list.OrderByDescending(x => x.Name)) :
                        list;
                }
            }

            //pagination

            var skipResults = (parameters.PageNumber - 1) * parameters.PageSize;

            return await list.Skip(skipResults).Take(parameters.PageSize).ToListAsync();

         
        }

       
    }
}
