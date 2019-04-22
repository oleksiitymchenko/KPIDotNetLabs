using CrudWebService.DTOModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace CrudWebService.Services
{
    public class GenericWebService<DtoType, ModelType> : WebService where DtoType : IBaseDto where ModelType : IEntity
    {
        private BaseService<DtoType, ModelType> baseService { get; set; } = new BaseService<DtoType, ModelType>();

        [WebMethod]
        public DtoType CreateEntity(DtoType entity)
        {
            try
            {
                return baseService.CreateEntity(entity);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        [WebMethod]
        public List<DtoType> GetEntities(DtoType entity)
        {
            try
            {
                return baseService.GetEntities();
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        [WebMethod]
        public bool UpdateEntity(DtoType entity)
        {
            try
            {
                return baseService.UpdateEntity(entity);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        [WebMethod]
        public bool DeleteEntity(string id)
        {
            try
            {
                return baseService.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}