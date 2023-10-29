using Project.Model.Common;

namespace Project.Model
{
    public class VehicleModelModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set;}

        public int MakeId {  get; set; }
    }
}