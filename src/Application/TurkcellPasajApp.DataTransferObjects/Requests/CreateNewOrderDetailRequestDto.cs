using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewOrderDetailRequestDto
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int OrderProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int OrderDetailsSellerId { get; set; }
    }
}
