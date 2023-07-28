using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IMapper _mapper;

        public FavouriteService(IFavouriteRepository favouriteRepository, IMapper mapper)
        {
            _favouriteRepository = favouriteRepository;
            _mapper = mapper;
        }

        public void ChangeFavouriteStatu(int favouriteId)
        {
            _favouriteRepository.ChangeFavouriteStatu(favouriteId);
        }

        public async Task ChangeFavouriteStatuAsync(int favouriteId)
        {
            await _favouriteRepository.ChangeFavouriteStatuAsync(favouriteId);
        }

        public void CreateNewFavourite(CreateNewFavouriteRequestDto createNewFavouriteRequestDto)
        {
            var favourite=_mapper.Map<Favourite>(createNewFavouriteRequestDto);
            _favouriteRepository.Create(favourite);
        }

        public async Task CreateNewFavouriteAsync(CreateNewFavouriteRequestDto createNewFavouriteRequestDto)
        {
            var favourite = _mapper.Map<Favourite>(createNewFavouriteRequestDto);
            await _favouriteRepository.CreateAsync(favourite);
        }

        public IEnumerable<FavouriteDisplayResponseDto> GetCustomersAllFavourites(int customerId)
        {
            var customersFavourites=_favouriteRepository.GetCustomerAllFavourites(customerId);
            return _mapper.Map<IEnumerable<FavouriteDisplayResponseDto>>(customersFavourites);
        }

        public async Task<IEnumerable<FavouriteDisplayResponseDto>> GetCustomersAllFavouritesAsync(int customerId)
        {
            var customersFavourites =await _favouriteRepository.GetCustomerAllFavouritesAsync(customerId);
            return _mapper.Map<IEnumerable<FavouriteDisplayResponseDto>>(customersFavourites);
        }
    }
}
