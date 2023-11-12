using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Resources
{
    public class UpdateVehicleModelResource
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name has to be minimum 2 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name has to be minimum 2 characters")]
        public string Abrv { get; set; }

        [Required]
        public int MakeId { get; set; }
    }


}
