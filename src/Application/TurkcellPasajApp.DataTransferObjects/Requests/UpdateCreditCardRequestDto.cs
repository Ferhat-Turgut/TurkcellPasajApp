using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateCreditCardRequestDto
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [MaxLength(50)]
        public string CardHolder { get; set; }
        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [MaxLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal AvaibleBalance { get; set; }

    }
}
