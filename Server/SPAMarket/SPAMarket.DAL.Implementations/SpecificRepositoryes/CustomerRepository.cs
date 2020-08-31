using SPAMarket.DAL.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAMarket.DAL.Implementations.SpecificRepositoryes
{
    public class CustomerRepository : RepositoryBase<CustomerEntity>
    {
        public CustomerRepository(DataContext rentalContext) : base(rentalContext)
        {
        }
    }
}