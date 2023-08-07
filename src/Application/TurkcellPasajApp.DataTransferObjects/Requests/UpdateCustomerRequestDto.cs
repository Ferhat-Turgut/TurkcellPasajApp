using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateCustomerRequestDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        [Required]
        [MaxLength(300)]
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
