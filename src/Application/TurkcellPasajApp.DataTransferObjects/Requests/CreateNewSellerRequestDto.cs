using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewSellerRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        
        [Required]
        [MaxLength(300)]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        

    }
}
