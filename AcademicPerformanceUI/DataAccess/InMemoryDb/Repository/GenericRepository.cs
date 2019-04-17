using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.InMemoryDb.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Group group: InMemoryLists.Groups.Add(group); break;
                case Student student: InMemoryLists.Students.Add(student); break;
                case Subject subject: InMemoryLists.Subjects.Add(subject); break;
                case Teacher teacher: InMemoryLists.Teachers.Add(teacher); break;
                case Test test: InMemoryLists.Tests.Add(test); break;
                case SubjectInGroup subjectInGroup: InMemoryLists.SubjectInGroups.Add(subjectInGroup); break;
                case TestResult testResult: InMemoryLists.TestResults.Add(testResult); break;
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            InMemoryLists.Students = InMemoryLists.Students.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Groups = InMemoryLists.Groups.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Subjects = InMemoryLists.Subjects.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Teachers = InMemoryLists.Teachers.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Tests = InMemoryLists.Tests.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.SubjectInGroups = InMemoryLists.SubjectInGroups.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.TestResults = InMemoryLists.TestResults.Where(x => x.Id != Id)
                               .ToList();

            return Task.FromResult(true);
        }

        public Task<List<TEntity>> GetAllEntitiesAsync()
        {
            var type = typeof(TEntity);
            List<IEntity> list = null;
            if (type == typeof(Group)) list =  InMemoryLists.Groups.Select(item => (IEntity)item).ToList();
            
            if (type == typeof(Student)) list = InMemoryLists.Students.Select(item => (IEntity)item).ToList();
            if (type == typeof(Subject)) list = InMemoryLists.Subjects.Select(item => (IEntity)item).ToList();
            if (type == typeof(Teacher)) list = InMemoryLists.Teachers.Select(item => (IEntity)item).ToList();
            if (type == typeof(Test)) list = InMemoryLists.Tests.Select(item => (IEntity)item).ToList();
            if (type == typeof(SubjectInGroup)) list = InMemoryLists.SubjectInGroups.Select(item => (IEntity)item).ToList();
            if (type == typeof(TestResult)) list = InMemoryLists.TestResults.Select(item => (IEntity)item).ToList();

            return Task.FromResult(list.Select(item => (TEntity)item).ToList());
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Group group:
                    {
                        var oldEntity = InMemoryLists.Groups.Find(o => o.Id == entity.Id);
                        oldEntity = (Group)entity.Clone();
                        break;
                    }
                case Student student:
                    {
                        var oldEntity = InMemoryLists.Students.Find(o => o.Id == entity.Id);
                        oldEntity = (Student)entity.Clone();
                        break;
                    }
                case Subject subject:
                    {
                        var oldEntity = InMemoryLists.Subjects.Find(o => o.Id == entity.Id);
                        oldEntity = (Subject)entity.Clone();
                        break;
                    }
                case Teacher teacher:
                    {

                        var oldEntity = InMemoryLists.Teachers.Find(o => o.Id == entity.Id);
                        oldEntity = (Teacher)entity.Clone();
                        break;
                    }
                case Test test:
                    {
                        var oldEntity = InMemoryLists.Tests.Find(o => o.Id == entity.Id);
                        oldEntity = (Test)entity.Clone();
                        break;
                    }
                case SubjectInGroup subjectInGroup:
                    {
                        var oldEntity = InMemoryLists.SubjectInGroups.Find(o => o.Id == entity.Id);
                        oldEntity = (SubjectInGroup)entity.Clone();
                        break;
                    }
                case TestResult testResult:
                    {
                        var oldEntity = InMemoryLists.TestResults.Find(o => o.Id == entity.Id);
                        oldEntity = (TestResult)entity.Clone();
                        break;
                    }
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public void AddCollection(List<TEntity> entities)
        {
            var type = typeof(TEntity);
            if (type == typeof(Group))
            {
                InMemoryLists.Groups.Clear();
            }
            if (type == typeof(Student))
            {
                InMemoryLists.Students.Clear();
            }
            if (type == typeof(Subject))
            {
                InMemoryLists.Subjects.Clear();
            }
            if (type == typeof(Teacher))
            {
                InMemoryLists.Teachers.Clear();
            }
            if (type == typeof(Test))
            {
                InMemoryLists.Tests.Clear();
            }
            if (type == typeof(SubjectInGroup))
            {
                InMemoryLists.SubjectInGroups.Clear();
            }
            if (type == typeof(TestResult))
            {
                InMemoryLists.TestResults.Clear();
            }
            entities.ForEach(item => CreateAsync(item));
            //throw new Exception("No such types");
        }

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity);
            IEntity newObject = null;
            if (type == typeof(Group)) newObject = new Group();
            if (type == typeof(Student)) newObject = new Student();
            if (type == typeof(Subject)) newObject = new Subject();
            if (type == typeof(Teacher)) newObject = new Teacher();
            if (type == typeof(Test)) newObject = new Test();
            if (type == typeof(SubjectInGroup)) newObject = new SubjectInGroup();
            if (type == typeof(TestResult)) newObject = new TestResult();
            return (TEntity)newObject;
        }
    }
}
