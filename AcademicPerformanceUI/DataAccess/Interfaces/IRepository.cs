using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IRepository<Entity> where Entity:IEntity
    {
    }
}
