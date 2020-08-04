using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SPAMarket.DAL.Contracts.Entities
{
    public class OrderEntity : BaseEntity
    {
        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; }
        public Guid CustomerId         { get; set; }

        public DateTime OrderDate    { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int      OrderNumber  { get; set; }
        public string Status       { get; set; }
    }
}
