using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class VehicleMakeModel : IVehicleMakeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Abrv {  get; set; }

        public List<VehicleModelModel> Models { get; set; } = new List<VehicleModelModel>();
    }
}