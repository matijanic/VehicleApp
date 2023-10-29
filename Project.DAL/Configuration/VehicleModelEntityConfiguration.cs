using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.DAL.Configuration
{
    public class VehicleModelEntityConfiguration : IEntityTypeConfiguration<VehicleModelEntity>
    {
        public void Configure(EntityTypeBuilder<VehicleModelEntity> builder)
        {
            builder.HasData(

                new VehicleModelEntity
                {
                    Id = 1,
                    Name = "X5",
                    Abrv = "X5",
                    MakeId = 1
                },

                new VehicleModelEntity
                {
                    Id = 2,
                    Name = "Passat 8",
                    Abrv = "Passat osmica",
                    MakeId = 2
                },

                new VehicleModelEntity
                {
                    Id = 3,
                    Name = "Golf 7",
                    Abrv = "Golf sedmica",
                    MakeId = 2
                });

        }
    }
}
