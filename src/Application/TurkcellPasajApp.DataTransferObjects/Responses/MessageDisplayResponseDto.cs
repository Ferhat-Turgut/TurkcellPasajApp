namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class MessageDisplayResponseDto
    {
        public int Id { get; set; }
        public string ReceiverMail { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime MailDate { get; set; }
    }
}
