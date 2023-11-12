using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Resources
{
    public class CreateVehicleMakeResource
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name has to be minimun 3 characters")]
        [MaxLength(30, ErrorMessage = "Name has to be maximum 30 characters")]
        public string Name { get; set; }
       
        
        
        [MinLength(2, ErrorMessage = "Code has to be minimun 2 characters")]
        [MaxLength(4, ErrorMessage = "Name has to be maximum 4 characters")]
        [Required]
        public string Abrv { get; set; }
    }


}
