using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Domain.Contracts
{
    public interface IOrderItemService
    {
        Task<Guid> Create(OrderItemModel product);

        OrderItemModel Get(Guid id);
        List<OrderItemModel> GetAll(Guid orderid);


        Task<Guid> AddItem(Guid id);
        Task<Guid> RemoveItem(Guid id);

        Task Delete(Guid id);
    }
}