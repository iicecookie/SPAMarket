using SPAMarket.DAL.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAMarket.DAL.Implementations.SpecificRepositoryes
{
    public class OrderRepository : RepositoryBase<OrderEntity>
    {
        public OrderRepository(DataContext rentalContext) : base(rentalContext)
        {
        }
    }
}
