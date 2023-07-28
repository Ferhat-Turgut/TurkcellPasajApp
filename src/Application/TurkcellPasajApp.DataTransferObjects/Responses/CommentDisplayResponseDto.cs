using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class CommentDisplayResponseDto
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public int CommentProductId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
