using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteDisplayResponseDto>> GetCustomersAllFavouritesAsync(int customerId);
        IEnumerable<FavouriteDisplayResponseDto> GetCustomersAllFavourites(int customerId);
        Task CreateNewFavouriteAsync(CreateNewFavouriteRequestDto createNewFavouriteRequestDto);
        void CreateNewFavourite(CreateNewFavouriteRequestDto createNewFavouriteRequestDto);
        Task ChangeFavouriteStatuAsync(int favouriteId);
        void ChangeFavouriteStatu(int favouriteId);
    }
}
