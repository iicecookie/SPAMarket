using System;
using AutoMapper;
using System.Threading.Tasks;
using SPAMarket.DAL.Contracts;
using SPAMarket.Domain.Contracts;
using System.Collections.Generic;
using SPAMarket.Domain.Contracts.Models;
using SPAMarket.DAL.Contracts.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SPAMarket.Domain.Implementations.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper       _mapper;

        public OrderItemService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper       = mapper;
        }

        public async Task<Guid> Create(OrderItemModel orderItem)
        {
            var entity = _mapper.Map<OrderItemEntity>(orderItem);
            var result = await _dbRepository.Add(entity);

            return result;
        }

        public OrderItemModel Get(Guid id)
        {
            var entity = _dbRepository.Get<OrderItemEntity>().FirstOrDefault(x => x.Id == id);
            var model  = _mapper.Map<OrderItemModel>(entity);

            return model;
        }

        public List<OrderItemModel> GetAll(Guid orderid)
        {
            var collection = _dbRepository.GetAll<OrderItemEntity>()
                                          .Include(x => x.Order).Where(x => x.OrderId == orderid).ToList();
            var models = _mapper.Map<List<OrderItemModel>>(collection);

            return models;
        }

        public async Task<Guid> AddItem(Guid id)
        {
            var entity = _dbRepository.Get<OrderItemEntity>().Include(c=>c.Product).FirstOrDefault(x => x.Id == id);

            entity.ItemCount += 1;
            entity.ItemPrice += entity.Product.Price;

            await _dbRepository.Update<OrderItemEntity>(entity);

            await _dbRepository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> RemoveItem(Guid id)
        {
            var entity = _dbRepository.Get<OrderItemEntity>().Include(c => c.Product).FirstOrDefault(x => x.Id == id);

            if (entity.ItemCount == 1)
            {
                return entity.Id;
            }

            entity.ItemCount -= 1;
            entity.ItemPrice -= entity.Product.Price;

            await _dbRepository.Update<OrderItemEntity>(entity);

            await _dbRepository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<OrderItemEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
