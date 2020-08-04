using System;
using System.Collections.Generic;

namespace SPAMarket.Domain.Contracts.Models
{
    public class CustomerModel
    {
        public Guid Id  { get; set; }
        public string Name     { get; set; }
        public string Code     { get; set; }
        public string Address  { get; set; }
        public byte   Discount { get; set; }

        public List<OrderModel> Orders { get; set; }
    }
}