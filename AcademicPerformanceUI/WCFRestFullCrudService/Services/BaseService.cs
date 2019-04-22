using DataAccess.Interfaces;
using DA = DataAccess.Models;
using DataAccess.SqlDbConnection;
using System;
using System.Collections.Generic;
using WCFRestFullCrudService.Services;
using WCFRestFullCrudService.DTOModels;

namespace WCFRestFullCrudService
{
    public class BaseService<T> where T: IBaseDto
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olexi\Downloads\TestDb.mdf;Integrated Security=True;Connect Timeout=30";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));
        private static Mapper mapper { get; set; } =  new Mapper(); 
        public virtual T CreateEntity(T entity)
        {
            try
            {
                var createdEntity = GetRepository().CreateAsync(mapper.MapToModel(entity)).Result;
                return mapper.MapToDto<T>(createdEntity);
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
                var isDeleted = GetRepository().DeleteAsync(Guid.Parse(id)).Result;
                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual List<T> GetEntities()
        {
            var group = new Group { GroupName = "12321", StudyYear = 2, MaxStudents = 20 };
            var x = (IBaseDto)group;
            return new List<T>() { (T)x };
            try
            {
                var list = GetRepository().GetAllEntitiesAsync().Result;
                var newList = new List<T>();
                list.ForEach(item => newList.Add(mapper.MapToDto<T>(item)));
                return newList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual bool UpdateEntity(T entity)
        {
            try
            {
                var updatedEntity = GetRepository().UpdateAsync(mapper.MapToModel(entity)).Result;
                return updatedEntity != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IRepository<IEntity> GetRepository()
        {
            var typeName = typeof(T).Name;
            switch (typeName)
            {
                case "Group": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.Group>();
                case "Student": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.Student>();
                case "Subject": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.Subject>();
                case "SubjectInGroup": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.SubjectInGroup>();
                case "Teacher": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.Teacher>();
                case "Test": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.Test>();
                case "TestResult": return (IRepository<IEntity>)UnitOfWork.Value.GetRepositoryByEntityType<DA.TestResult>();
                default: throw new NotSupportedException();
            }
        }
    }
}