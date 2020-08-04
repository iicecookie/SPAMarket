using System;
using System.Collections.Generic;
using System.Text;

namespace SPAMarket.DAL.Contracts.Entities
{
    public class UserEntity
    {
        public Guid Id               { get; set; }
        public string Login          { get; set; }
        public string HashedPassword { get; set; }
    }
}
