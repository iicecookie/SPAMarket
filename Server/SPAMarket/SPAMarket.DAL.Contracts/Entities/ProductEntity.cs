
namespace SPAMarket.DAL.Contracts.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Code     { get; set; }
        public string Name     { get; set; }
        public int    Price    { get; set; }
        public string Category { get; set; }
    }
}