using Project.DAL;

namespace Project.WebAPI.Resources
{
    public class VehicleModelWithVehicleMakeResource
    {
        public string Name { get; set; }

        public string Abrv { get; set; }



        public VehicleMakeResources VehicleMake { get; set; }
    }
}
