using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewCategoryRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
