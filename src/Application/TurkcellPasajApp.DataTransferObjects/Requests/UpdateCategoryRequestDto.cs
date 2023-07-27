using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateCategoryRequestDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
