using Microsoft.VisualBasic;
using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UnitOfWork : IUnitOfWork

    {

        private readonly VehicleDbContext _db;
        private VehicleMakeRepository _vehicleMakeRepository;
        private VehicleModelRepository _vehicleModelRepostiry;

        public UnitOfWork(VehicleDbContext db)
        {
            this._db = db;
        }
        public IVehicleMakeRepository VehicleMakes
        {
            get
            {
                if (_vehicleMakeRepository == null)
                {
                    _vehicleMakeRepository = new VehicleMakeRepository(_db);
                }
                return _vehicleMakeRepository;
            }
        }



        public IVehicleModelRepository VehicleModels
        {
            get
            {
                if (_vehicleModelRepostiry == null)
                {
                    _vehicleModelRepostiry = new VehicleModelRepository(_db);
                }

                return (_vehicleModelRepostiry);
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
           _db.Dispose();
        }
    }
}
