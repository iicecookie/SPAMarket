using System;

namespace SPAMarket.Domain.Contracts.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }

        public OrderModel Order { get; set; }
        public Guid     OrderId { get; set; }

        public ProductModel Product { get; set; }
        public Guid       ProductId { get; set; }

        public uint ItemCount { get; set; }
        public int  ItemPrice { get; set; }
    }
}