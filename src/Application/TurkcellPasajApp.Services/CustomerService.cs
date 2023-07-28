using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public void CreateCustomer(CreateNewCustomerRequestDto createNewCustomerRequestDto)
        {
            var newCustomer = _mapper.Map<Customer>(createNewCustomerRequestDto);
            _customerRepository.Create(newCustomer);
        }

        public async Task CreateCustomerAsync(CreateNewCustomerRequestDto createNewCustomerRequestDto)
        {
            var newCustomer = _mapper.Map<Customer>(createNewCustomerRequestDto);
            await _customerRepository.CreateAsync(newCustomer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public CustomerDisplayResponseDto GetCustomerById(int customerId)
        {
            var customer = _customerRepository.Get(customerId);
            return _mapper.Map<CustomerDisplayResponseDto>(customer);
        }

        public async Task<CustomerDisplayResponseDto> GetCustomerByIdAsync(int customerId)
        {
            var customer =await _customerRepository.GetAsync(customerId);
            return _mapper.Map<CustomerDisplayResponseDto>(customer);
        }

        public void UpdateCustomer(UpdateCustomerRequestDto updateCustomerRequestDto)
        {
            var updateCustomer=_mapper.Map<Customer>(updateCustomerRequestDto);
            _customerRepository.Update(updateCustomer);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerRequestDto updateCustomerRequestDto)
        {
            var updateCustomer = _mapper.Map<Customer>(updateCustomerRequestDto);
            await _customerRepository.UpdateAsync(updateCustomer);
        }
    }
}
