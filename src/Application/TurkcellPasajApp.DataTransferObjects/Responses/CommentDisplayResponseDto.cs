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
