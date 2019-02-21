using System;

namespace DataAccess.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
