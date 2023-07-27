namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class FavouriteDisplayResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FavouriteProductId { get; set; }
        public bool IsFavourite { get; set; }
    }
}
