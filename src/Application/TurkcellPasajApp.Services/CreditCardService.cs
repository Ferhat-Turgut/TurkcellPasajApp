using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public CreditCardService(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public void CreateNewCreditCard(CreateNewCategoryRequestDto createNewCategoryRequestDto)
        {
            var newCreditCard = _mapper.Map<CreditCard>(createNewCategoryRequestDto);
            _creditCardRepository.Create(newCreditCard);
        }

        public async Task CreateNewCreditCardAsync(CreateNewCategoryRequestDto createNewCategoryRequestDto)
        {
            var newCreditCard = _mapper.Map<CreditCard>(createNewCategoryRequestDto);
            await _creditCardRepository.CreateAsync(newCreditCard);
        }

        public void DeleteCreditCard(int creditCardId)
        {
            _creditCardRepository.Delete(creditCardId);
        }

        public async Task DeleteCreditCardAsync(int creditCardId)
        {
            await _creditCardRepository.DeleteAsync(creditCardId);
        }

        public CreditCardDisplayResponseDto GetCreditCardById(int creditCardId)
        {
            var creditCard=_creditCardRepository.Get(creditCardId);
            return _mapper.Map<CreditCardDisplayResponseDto>(creditCard);
        }

        public async Task<CreditCardDisplayResponseDto> GetCreditCardByIdAsync(int creditCardId)
        {
            var creditCard =await _creditCardRepository.GetAsync(creditCardId);
            return _mapper.Map<CreditCardDisplayResponseDto>(creditCard);
        }

        public IEnumerable<CreditCardDisplayResponseDto>? GetCreditCardsByCustomerId(int customerId)
        {
            var usersCreditCards = _creditCardRepository.GetCreditCardsByCustomerId(customerId);
            return _mapper.Map<IEnumerable<CreditCardDisplayResponseDto>>(usersCreditCards);
        }

        public async Task<IEnumerable<CreditCardDisplayResponseDto>>? GetCreditCardsByCustomerIdAsync(int customerId)
        {
            var usersCreditCards =await _creditCardRepository.GetCreditCardsByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<CreditCardDisplayResponseDto>>(usersCreditCards);
        }
    }
}
