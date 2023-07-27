using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewMessageRequestDto
    {
        [Required]
        public string ReceiverMail { get; set; }
        [Required]
        public string SenderMail { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        [Required]
        public DateTime MailDate { get; set; }
    }
}
