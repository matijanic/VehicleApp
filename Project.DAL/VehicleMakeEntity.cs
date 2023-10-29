namespace Project.DAL
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public List<VehicleModelEntity> Models { get; set; } = new List<VehicleModelEntity>();
    } 
}