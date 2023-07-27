using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewOrderRequestDto
    {
        [Required]
        public string Status { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
