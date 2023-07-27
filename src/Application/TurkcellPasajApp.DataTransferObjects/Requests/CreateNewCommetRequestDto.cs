using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewCommetRequestDto
    {
       
        [Required]
        [MaxLength(500)]
        public string CommentContent { get; set; }

        [Required]
        public int CommentProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
