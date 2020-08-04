using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPAMarket.DAL.Contracts.Entities;

namespace SPAMarket.DAL.Implementations
{
    public class DataContext : DbContext
    {   
        public DbSet<UserEntity>      Users      { get; set; }
        public DbSet<OrderEntity>     Orders     { get; set; }
        public DbSet<ProductEntity>   Products   { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<CustomerEntity>  Customers  { get; set; }


        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
