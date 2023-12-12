using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Resources
{
    public class CreateVehicleModelResource
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name has to be minimum 2 characters")]
        [MaxLength(30, ErrorMessage = "Name has to be maximum 30 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name has to be minimum 2 characters")]
        [MaxLength(4, ErrorMessage = "Abrv has to be maximum 4 characters")]
        public string Abrv { get; set; }

        [Required]
        public int MakeId { get; set; }
    }


}
