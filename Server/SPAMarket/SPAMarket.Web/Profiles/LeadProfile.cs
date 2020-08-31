using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPAMarket.Domain.Contracts.Models;
using SPAMarket.DAL.Contracts.Entities;

namespace SPAMarket.Web.Profiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerModel>();

            CreateMap<OrderItemModel, OrderItemEntity>();
            CreateMap<OrderItemEntity, OrderItemModel>();

            CreateMap<OrderModel, OrderEntity>();
            CreateMap<OrderEntity, OrderModel>();

            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();

            CreateMap<List<ProductModel>, List<ProductEntity>>();
            CreateMap<List<ProductEntity>, List<ProductModel>>();

            CreateMap<List<OrderModel>, List<OrderEntity>>();
            CreateMap<List<OrderEntity>, List<OrderModel>>();

            CreateMap<List<OrderItemModel>, List<OrderItemEntity>>();
            CreateMap<List<OrderItemEntity>, List<OrderItemModel>>();
        }
    }
}