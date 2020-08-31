using Microsoft.EntityFrameworkCore;
using SPAMarket.DAL.Contracts.Entities;

namespace SPAMarket.DAL.Implementations.SpecificRepositoryes
{
    public class ProductRepository : RepositoryBase<ProductEntity>
    {
        public ProductRepository(DataContext rentalContext) : base(rentalContext)
        {
        }
    }
}
