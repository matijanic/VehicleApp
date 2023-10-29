using Microsoft.EntityFrameworkCore;
using Project.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class VehicleDbContext : DbContext
    {

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) 
        {

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MakeId iz tablice VehicleModelEntity postavljen kao ForeignKey
            modelBuilder.Entity<VehicleModelEntity>().HasOne(vm => vm.VehicleMake).WithMany(v => v.Models).HasForeignKey(vm => vm.MakeId);

            modelBuilder.ApplyConfiguration(new VehicleMakeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelEntityConfiguration());

        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
    }
}
