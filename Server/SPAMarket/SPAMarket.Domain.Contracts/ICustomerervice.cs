using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Domain.Contracts
{
    public interface ICustomerService
    {
        Task<Guid> Create(CustomerModel product);
        Task<CustomerModel> Get(Guid id);
        Task<Guid> Update(CustomerModel product);
    }
}