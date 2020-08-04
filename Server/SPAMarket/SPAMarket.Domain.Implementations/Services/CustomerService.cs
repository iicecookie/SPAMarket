﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPAMarket.DAL.Contracts.Entities;
using SPAMarket.DAL.Contracts;
using SPAMarket.Domain.Contracts;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Domain.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public CustomerService(IDbRepository dbRepository, IMapper mapper)
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
            var entity = await _dbRepository.Get<CustomerEntity>().FirstOrDefaultAsync(x => x.Id == id);
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