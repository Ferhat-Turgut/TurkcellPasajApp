using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Comment 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string CommentContent { get; set; }

        [Required]
        public int CommentProductId { get; set; }
        public Product CommentProduct { get; set; }
        public Customer? Customer { get; set; }
        public Seller? Seller { get; set; }

    }
}
