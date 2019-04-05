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
                case Group group: InMemory.Groups.Add(group); break;
                case Student student: InMemory.Students.Add(student); break;
                case Subject subject: InMemory.Subjects.Add(subject); break;
                case Teacher teacher: InMemory.Teachers.Add(teacher); break;
                case Test test: InMemory.Tests.Add(test); break;
                case SubjectInGroup subjectInGroup: InMemory.SubjectInGroups.Add(subjectInGroup); break;
                case TestResult testResult: InMemory.TestResults.Add(testResult); break;
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            InMemory.Students = InMemory.Students.Where(x => x.Id != Id)
                               .ToList();
            InMemory.Groups = InMemory.Groups.Where(x => x.Id != Id)
                               .ToList();
            InMemory.Subjects = InMemory.Subjects.Where(x => x.Id != Id)
                               .ToList();
            InMemory.Teachers = InMemory.Teachers.Where(x => x.Id != Id)
                               .ToList();
            InMemory.Tests = InMemory.Tests.Where(x => x.Id != Id)
                               .ToList();
            InMemory.SubjectInGroups = InMemory.SubjectInGroups.Where(x => x.Id != Id)
                               .ToList();
            InMemory.TestResults = InMemory.TestResults.Where(x => x.Id != Id)
                               .ToList();

            return Task.FromResult(true);
        }

        public Task<List<TEntity>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
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
                        var oldEntity = InMemory.Groups.Find(o => o.Id == entity.Id);
                        oldEntity = (Group)entity.Clone();
                        break;
                    }
                case Student student:
                    {
                        var oldEntity = InMemory.Students.Find(o => o.Id == entity.Id);
                        oldEntity = (Student)entity.Clone();
                        break;
                    }
                case Subject subject:
                    {
                        var oldEntity = InMemory.Subjects.Find(o => o.Id == entity.Id);
                        oldEntity = (Subject)entity.Clone();
                        break;
                    }
                case Teacher teacher:
                    {
                        var oldEntity = InMemory.Teachers.Find(o => o.Id == entity.Id);
                        oldEntity = (Teacher)entity.Clone();
                        break;
                    }
                case Test test:
                    {
                        var oldEntity = InMemory.Tests.Find(o => o.Id == entity.Id);
                        oldEntity = (Test)entity.Clone();
                        break;
                    }
                case SubjectInGroup subjectInGroup:
                    {
                        var oldEntity = InMemory.SubjectInGroups.Find(o => o.Id == entity.Id);
                        oldEntity = (SubjectInGroup)entity.Clone();
                        break;
                    }
                case TestResult testResult:
                    {
                        var oldEntity = InMemory.TestResults.Find(o => o.Id == entity.Id);
                        oldEntity = (TestResult)entity.Clone();
                        break;
                    }
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public void ReplaceCollection(List<TEntity> entities)
        {
            var type = typeof(TEntity);
            if (type == typeof(Group))
            {
                InMemory.Groups.Clear();
            }
            if (type == typeof(Student))
            {
                InMemory.Students.Clear();
            }
            if (type == typeof(Subject))
            {
                InMemory.Subjects.Clear();
            }
            if (type == typeof(Teacher))
            {
                InMemory.Teachers.Clear();
            }
            if (type == typeof(Test))
            {
                InMemory.Tests.Clear();
            }
            if (type == typeof(SubjectInGroup))
            {
                InMemory.SubjectInGroups.Clear();
            }
            if (type == typeof(TestResult))
            {
                InMemory.TestResults.Clear();
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
