using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewOrderRequestDto
    {
        [Required]
        public string Status { get; set; } = "created";
        [Required]
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
