﻿
namespace SPAMarket.DAL.Contracts.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Name     { get; set; }
        public string Code     { get; set; }
        public string Address  { get; set; }
        public byte   Discount { get; set; }

        public string Login          { get; set; }
        public string HashedPassword { get; set; }
    }
}
