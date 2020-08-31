using SPAMarket.DAL.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAMarket.DAL.Implementations.SpecificRepositoryes
{
    public class OrderItemRepository : RepositoryBase<OrderItemEntity>
    {
        public OrderItemRepository(DataContext rentalContext) : base(rentalContext)
        {
        }
    }
}