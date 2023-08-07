﻿using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CreateNewCustomerRequestDto createNewCustomerRequestDto);
        void CreateCustomer(CreateNewCustomerRequestDto createNewCustomerRequestDto);
        Task DeleteCustomerAsync(int id);
        void DeleteCustomer(int id);
        Task UpdateCustomerAsync(UpdateCustomerRequestDto updateCustomerRequestDto);
        void UpdateCustomer(UpdateCustomerRequestDto updateCustomerRequestDto);
        CustomerDisplayResponseDto GetCustomerById(int customerId);
        Task<CustomerDisplayResponseDto> GetCustomerByIdAsync(int customerId);
        Customer? GetCustomerByUsername(string username);
        Task<Customer>? GetCustomerByUsernameAsync(string username);
    }
}
