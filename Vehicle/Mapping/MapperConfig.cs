using AutoMapper;
using Project.DAL;
using Project.Model;
using Project.WebAPI.Resources;

namespace Project.WebAPI.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<VehicleMakeEntity, VehicleMakeModel>().ReverseMap();
            CreateMap<VehicleMakeModel , VehicleMakeResources>().ReverseMap();
            CreateMap<CreateVehicleMakeResource, VehicleMakeModel>().ReverseMap();
            CreateMap<VehicleMakeModel,VehicleMakeWithModelsResources>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMakeEntity>().ReverseMap();
            CreateMap<UpdateVehicleMakeResource, VehicleMakeModel>().ReverseMap();
            
            CreateMap<VehicleModelEntity, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModelModel,VehicleModelResources>().ReverseMap();
            CreateMap<CreateVehicleModelResource, VehicleModelModel>().ReverseMap();
            CreateMap<UpdateVehicleModelResource, VehicleModelModel>().ReverseMap();

            
            
            








        }

    }
}
