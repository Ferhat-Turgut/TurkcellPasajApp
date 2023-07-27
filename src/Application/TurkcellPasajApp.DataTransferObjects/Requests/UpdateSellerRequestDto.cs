using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateSellerRequestDto
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
