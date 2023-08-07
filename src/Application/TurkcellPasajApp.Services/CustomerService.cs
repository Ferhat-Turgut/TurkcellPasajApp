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

        public CustomerDisplayResponseDto GetCustomerById(int id)
        {
            var customer = _customerRepository.Get(id);
            return _mapper.Map<CustomerDisplayResponseDto>(customer);
        }

        public async Task<CustomerDisplayResponseDto> GetCustomerByIdAsync(int id)
        {
            var customer =await _customerRepository.GetAsync(id);
            return _mapper.Map<CustomerDisplayResponseDto>(customer);
        }

        public Customer? GetCustomerByUsername(string username)
        {
            var customer=_customerRepository.GetCustomerByUsername(username);
            return customer;
        }

        public async Task<Customer>? GetCustomerByUsernameAsync(string username)
        {
            var customer =await _customerRepository.GetCustomerByUsernameAsync(username);
            return customer;
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
