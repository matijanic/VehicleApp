using Project.Model.Common;

namespace Project.Model
{
    public class VehicleModelModel : IVehicleModelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set;}

        public int MakeId {  get; set; }
        public VehicleMakeModel VehicleMake { get; set; }
    }
}