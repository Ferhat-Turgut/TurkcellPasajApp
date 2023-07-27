using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewCustomerRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        [Required]
        [MaxLength(300)]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }


    }
}
