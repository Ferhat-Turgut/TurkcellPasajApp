using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewSellerRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Address { get; set; }
      
    }
}
