using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPAMarket.DAL.Contracts.Entities;
using SPAMarket.DAL.Contracts;
using SPAMarket.Domain.Contracts;
using SPAMarket.Domain.Contracts.Models;
using SPAMarket.DAL.Implementations.SpecificRepositoryes;
using SPAMarket.DAL.Implementations;

namespace SPAMarket.Domain.Implementations.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _dbRepository;
        private readonly IMapper _mapper;

        public OrderService(OrderRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(List<OrderItemModel> orderItems)
        {
            var entity = _mapper.Map<List<OrderItemEntity>>(orderItems);
            await new UnitOfWork().OrderItems.AddRange(entity);

            var order = new OrderModel()
            {
                Status = "New",
                OrderItems = orderItems,
                CustomerId = Guid.NewGuid(), // TODO:
                OrderNumber = _dbRepository.GetAll().Count(),
                OrderDate = DateTime.Now,
            };

            var result = await _dbRepository.Add(_mapper.Map<OrderEntity>(order));

            return result;  
        }

        public OrderModel Get(Guid id)
        {
            var entity = _dbRepository.Get().FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<OrderModel>(entity);

            return model;
        }

        public List<OrderModel> GetAll()
        {
            var collection = _dbRepository.GetAll().Include(x => x.Customer).ToList();
            var models = _mapper.Map<List<OrderModel>>(collection);

            return models;
        }

        public async Task<Guid> Update(OrderModel order)
        {
            var entity = _mapper.Map<OrderEntity>(order);

            await _dbRepository.Update(entity);
            await _dbRepository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var model = Get(id);
            if (model.Status != "In progress")
            {
                await new UnitOfWork().Products.Delete(id);
                await _dbRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}