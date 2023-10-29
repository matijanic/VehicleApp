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
                .Include(a=>a.Models)
                .ToListAsync();
        return allList;
        }

        public async Task<VehicleMakeEntity> GetWithModelsByIdAsync(int Id)
        {
            var entity = await _db.VehicleMakes
                .Include(a=> a.Models)
                .FirstOrDefaultAsync(a=> a.Id == Id);

            return entity;
        }
    }
}
