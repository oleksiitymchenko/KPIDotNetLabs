using System;

namespace DataAccess.Interfaces
{
    public interface IEntity:ICloneable
    {
        Guid Id { get; set; }
    }
}
