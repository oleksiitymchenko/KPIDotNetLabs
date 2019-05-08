using DataAccess.Interfaces;
using DataAccess.SqlDbConnection;
using System;
using System.Collections.Generic;
using WcfRestService.Services;
using WcfRestService.DTOModels;

namespace WcfRestService
{
    public class BaseService<DtoType, ModelType> where DtoType: IBaseDto where ModelType: IEntity
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a.timchenko\DOCUMENTS\TestTest.mdf;Integrated Security=True;Connect Timeout=30";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));
        private Mapper mapper { get; set; } =  new Mapper();

        IRepository<ModelType> Repository = null;
        public BaseService(IRepository<ModelType> repository)
        {
            Repository = repository;
        }

        public BaseService()
        {

        }

        public virtual DtoType CreateEntity(DtoType entity)
        {
            try
            {
                mapper = new Mapper();
                Console.WriteLine(entity);
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var modelEntity = (ModelType)mapper.MapToModel((IBaseDto)entity);
                var createdEntity = repository.CreateAsync(modelEntity).Result;
                return (DtoType)mapper.MapToDto<DtoType>(createdEntity);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public virtual bool DeleteEntity(string id)
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var isDeleted = repository.DeleteAsync(Guid.Parse(id)).Result;
                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual List<DtoType> GetEntities()
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var list = repository.GetAllEntitiesAsync().Result;
                var newList = new List<DtoType>();
                list.ForEach(item => newList.Add((DtoType)mapper.MapToDto<DtoType>(item)));
                return newList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual bool UpdateEntity(DtoType entity)
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var updatedEntity = repository.UpdateAsync((ModelType)mapper.MapToModel(entity)).Result;
                return updatedEntity != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}