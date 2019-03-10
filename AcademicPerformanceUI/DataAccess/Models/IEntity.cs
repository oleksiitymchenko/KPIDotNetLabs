using System;

namespace DataAccess.Models
{
    public interface IEntity:ICloneable
    {
        Guid Id { get; set; }
    }
}
