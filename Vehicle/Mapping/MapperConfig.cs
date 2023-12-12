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
            CreateMap<ChangeVehicleMakeResource, VehicleMakeModel>().ReverseMap();
            CreateMap<VehicleMakeModel,VehicleMakeWithModelsResources>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMakeEntity>().ReverseMap();
           
            
            CreateMap<VehicleModelEntity, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModelModel,VehicleModelResources>().ReverseMap();
            CreateMap<ChangeVehicleModelResource, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelWithVehicleMakeResource,VehicleModelModel>().ReverseMap();

            
            
            








        }

    }
}
