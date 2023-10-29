﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DAL;

#nullable disable

namespace Project.DAL.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.DAL.VehicleMakeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abrv = "B",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "WV",
                            Name = "Volkswagen"
                        });
                });

            modelBuilder.Entity("Project.DAL.VehicleModelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abrv = "X5",
                            MakeId = 1,
                            Name = "X5"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "Passat osmica",
                            MakeId = 2,
                            Name = "Passat 8"
                        },
                        new
                        {
                            Id = 3,
                            Abrv = "Golf sedmica",
                            MakeId = 2,
                            Name = "Golf 7"
                        });
                });

            modelBuilder.Entity("Project.DAL.VehicleModelEntity", b =>
                {
                    b.HasOne("Project.DAL.VehicleMakeEntity", "VehicleMake")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("Project.DAL.VehicleMakeEntity", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
