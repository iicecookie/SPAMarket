using System;
using System.Collections.Generic;

namespace SPAMarket.Domain.Contracts.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public CustomerModel Customer { get; set; }
        public Guid        CustomerId { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }

        public DateTime OrderDate     { get; set; }
        public DateTime ShipmentDate  { get; set; }
        public int      OrderNumber   { get; set; }
        public string   Status        { get; set; } // New, In progress, Done 
    }
}