using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Customer;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Address = customerModel.Address,
                ContactNo = customerModel.ContactNo,
                Accounts = customerModel.Accounts.Select(x => x.ToAccountDto()).ToList()
            };
        }

        public static Customer ToCustomerFromCreate(this CreateCustomerDto customerDto)
        {
            return new Customer
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                Email = customerDto.Email,
                ContactNo = customerDto.ContactNo
            };
        }

        public static Customer ToCustomerFromUpdate(this UpdateCustomerDto customerDto)
        {
            return new Customer
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                ContactNo = customerDto.ContactNo
            };
        }
    }
}