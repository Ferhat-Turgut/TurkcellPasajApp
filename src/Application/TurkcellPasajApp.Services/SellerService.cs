using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public void CreateSeller(CreateNewSellerRequestDto createNewSellerRequestDto)
        {
            var newSeller = _mapper.Map<Seller>(createNewSellerRequestDto);
            _sellerRepository.Create(newSeller);
        }

        public async Task CreateSellerAsync(CreateNewSellerRequestDto createNewSellerRequestDto)
        {
            var newSeller = _mapper.Map<Seller>(createNewSellerRequestDto);
            await _sellerRepository.CreateAsync(newSeller);
        }

        public void DeleteSeller(int sellerId)
        {
            _sellerRepository.Delete(sellerId);
        }

        public async Task DeleteSellerAsync(int sellerId)
        {
            await _sellerRepository.DeleteAsync(sellerId);
        }

        public SellerDisplayResponseDto GetSellerById(int sellerId)
        {
            var seller = _sellerRepository.Get(sellerId);
            return _mapper.Map<SellerDisplayResponseDto>(seller);
        }

        public async Task<SellerDisplayResponseDto> GetSellerByIdAsync(int sellerId)
        {
            var seller =await _sellerRepository.GetAsync(sellerId);
            return _mapper.Map<SellerDisplayResponseDto>(seller);
        }

        public SellerDisplayResponseDto? GetSellerByUsername(string username)
        {
            var seller = _sellerRepository.GetSellerByUsername(username);
            return _mapper.Map<SellerDisplayResponseDto>(seller);
        }

        public async Task<SellerDisplayResponseDto>? GetSellerByUsernameAsync(string username)
        {
            var seller =await _sellerRepository.GetSellerByUsernameAsync(username);
            return _mapper.Map<SellerDisplayResponseDto>(seller);
        }
    

        public void UpdateSeller(UpdateSellerRequestDto updateSellerRequestDto)
        {
            var updateSeller = _mapper.Map<Seller>(updateSellerRequestDto);
            _sellerRepository.Update(updateSeller);
        }

        public async Task UpdateSellerAsync(UpdateSellerRequestDto updateSellerRequestDto)
        {
            var updateSeller = _mapper.Map<Seller>(updateSellerRequestDto);
            await _sellerRepository.UpdateAsync(updateSeller);
        }
    }
}
