using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Domain.Contracts
{
    public interface IOrderService
    {
        Task<Guid> Create(List<OrderItemModel> orderItems);

        OrderModel Get(Guid id);
        List<OrderModel> GetAll();

        Task<Guid> Update(OrderModel product);

        Task<bool> Delete(Guid id);
    }
}