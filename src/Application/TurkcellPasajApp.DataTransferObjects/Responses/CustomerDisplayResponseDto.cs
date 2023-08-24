namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class CustomerDisplayResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public List<CreditCardDisplayResponseDto> creditCards { get; set; }

    }
}
