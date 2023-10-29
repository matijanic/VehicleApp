using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }
        
        
        public int MakeId { get; set; } 

        public VehicleMakeEntity VehicleMake { get; set; }


    }
}