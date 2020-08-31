using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPAMarket.DAL.Contracts.Entities;
using SPAMarket.Domain.Contracts;
using SPAMarket.Domain.Contracts.Models;
using SPAMarket.DAL.Implementations.SpecificRepositoryes;

namespace SPAMarket.Domain.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _dbRepository;
        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CustomerModel lead)
        {
            var entity = _mapper.Map<CustomerEntity>(lead); 

            var result = await _dbRepository.Add(entity);
            await _dbRepository.SaveChangesAsync();

            return result;
        }

        public async Task<CustomerModel> Get(Guid id)
        {
            var entity = await _dbRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<CustomerModel>(entity);
            await _dbRepository.SaveChangesAsync();
            return model;
        }

        public async Task<Guid> Update(CustomerModel lead)
        {
            var entity = _mapper.Map<CustomerEntity>(lead);

            await _dbRepository.Update(entity);
            await _dbRepository.SaveChangesAsync();

            return entity.Id;
        }
    }
}