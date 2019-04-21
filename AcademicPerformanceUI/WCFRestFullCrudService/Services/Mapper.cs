using DataAccess.Interfaces;
using Model = DataAccess.Models;
using Dto = WCFRestFullCrudService.DTOModels;
using System;

namespace WCFRestFullCrudService.Services
{
    public class Mapper
    {
        public IEntity MapToModel(Dto.IBaseDto entity)
        {
            var oldTypeName = entity.GetType().Name;
            switch (oldTypeName)
            {
                case "Group":
                    {
                        entity = (Dto.Group)entity;
                        return new Model.Group()
                        {

                        };
                    }
                default: throw new NotSupportedException();
            }
        }

        public T MapToDto<T>(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}