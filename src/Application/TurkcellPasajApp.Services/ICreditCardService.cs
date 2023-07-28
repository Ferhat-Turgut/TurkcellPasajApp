using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCardDisplayResponseDto>>? GetCreditCardsByCustomerIdAsync(int customerId);
        IEnumerable<CreditCardDisplayResponseDto>? GetCreditCardsByCustomerId(int customerId);
        Task CreateNewCreditCardAsync(CreateNewCategoryRequestDto createNewCategoryRequestDto);
        void CreateNewCreditCard(CreateNewCategoryRequestDto createNewCategoryRequestDto);
        Task DeleteCreditCardAsync(int creditCardId);
        void DeleteCreditCard(int creditCardId);
        Task<CreditCardDisplayResponseDto> GetCreditCardByIdAsync(int creditCardId);
        CreditCardDisplayResponseDto GetCreditCardById(int creditCardId);
    }
}

