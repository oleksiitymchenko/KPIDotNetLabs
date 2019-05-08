using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tests.MockRepositories
{
    public class GroupRepositoryMock:IRepository<Group>
    {
        private List<Group> groups = new List<Group>();

        public void AddCollection(List<Group> entities)
        {
            groups.AddRange(entities);
        }

        public Task<Group> CreateAsync(Group entity)
        {
            groups.Add(entity);
            return Task.FromResult(entity);
        }

        public Group CreateEmptyObject() => new Group();

        public Task<bool> DeleteAsync(Guid id)
        {
            groups = groups.Where(item => item.Id != id).ToList();
            return Task.FromResult(true);
        }

        public Task<List<Group>> GetAllEntitiesAsync() => Task.FromResult(groups);
        public Task<Group> GetFirstOrDefaultAsync(Expression<Func<Group, bool>> predicate = null)
        {
            Group group = null;
            if (predicate == null) group =  groups.FirstOrDefault();
            group = groups.AsQueryable().FirstOrDefault(predicate);
            return Task.FromResult(group);
        }
         

        public Task<Group> UpdateAsync(Group entity)
        {
            var group = groups.FirstOrDefault(item => item.Id == entity.Id);
            group.GroupName = entity.GroupName;
            group.MaxStudents = entity.MaxStudents;
            group.StudyYear = entity.StudyYear;
            return Task.FromResult(entity);
        }

        public void Clear()
        {
            groups = new List<Group>();
        }
    }
}
