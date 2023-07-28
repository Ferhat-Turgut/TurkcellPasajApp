namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class CustomerDisplayResponseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
