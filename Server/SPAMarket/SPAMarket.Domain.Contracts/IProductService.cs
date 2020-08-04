using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Domain.Contracts
{
    public interface IProductService
    {
        Task<Guid> Create(ProductModel product);

        ProductModel Get(Guid id);

        List<ProductModel> GetAll();
        
        Task<Guid> Update(ProductModel product);

        Task Delete(Guid id);
    }
}