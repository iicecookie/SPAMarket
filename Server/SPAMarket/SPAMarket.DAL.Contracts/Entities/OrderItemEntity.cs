using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAMarket.DAL.Contracts.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public OrderEntity Order { get; set; }
        public Guid      OrderId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
        public Guid        ProductId { get; set; }

        public uint ItemCount { get; set; }
        public int  ItemPrice { get; set; }
    }
}