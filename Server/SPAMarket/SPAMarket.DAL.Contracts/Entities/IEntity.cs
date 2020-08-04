using System;

namespace SPAMarket.DAL.Contracts.Entities
{
    public interface IEntity
    {
        Guid Id       { get; set; }
        bool IsActive { get; set; }
        DateTime  DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}