using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configuration
{
    public class VehicleMakeEntityConfiguration : IEntityTypeConfiguration<VehicleMakeEntity>
    {
        public void Configure(EntityTypeBuilder<VehicleMakeEntity> builder)
        {
            builder.HasData(
                new VehicleMakeEntity
                {
                    Id = 1,
                    Name = "BMW",
                    Abrv = "B"
                },

                new VehicleMakeEntity
                {
                    Id = 2,
                    Name = "Volkswagen",
                    Abrv = "WV"

                });
        }
    }
}
