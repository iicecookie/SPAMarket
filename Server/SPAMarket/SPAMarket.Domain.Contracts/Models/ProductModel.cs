using System;

namespace SPAMarket.Domain.Contracts.Models
{
    public class ProductModel
    {
        public Guid Id  { get; set; }
        public string Code     { get; set; }
        public string Name     { get; set; }
        public int    Price    { get; set; }
        public string Category { get; set; }
    }
}