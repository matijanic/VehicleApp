using Project.Model;

namespace Project.WebAPI.Resources
{
    public class VehicleMakeWithModelsResources
    {
        public string Name { get; set; }

        public string Abrv { get; set; }

        public List<VehicleModelResources> Models { get; set; }  

       
    }
}
