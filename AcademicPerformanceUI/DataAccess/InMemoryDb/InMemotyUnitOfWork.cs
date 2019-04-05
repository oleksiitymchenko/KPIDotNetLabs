using DataAccess.Interfaces;
using DataAccess.Models;
using System;

namespace DataAccess.InMemoryDb
{
    public class InMemotyUnitOfWork : IUnitOfWork
    {
       // public IUserCollectionRepository UserCollectionRepository => _userCollectionRepository ?? (_userCollectionRepository = new UserCollectionRepository(_context, _mapper));

        public IRepository<Group> GroupRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Student> StudentRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Subject> SubjectRepostitory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<SubjectInGroup> SubjectInGroupRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Teacher> TeacherRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Test> TestRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<TestResult> TestResultRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity
        {
            var entityType = typeof(Entity);

            if (entityType == typeof(Group)) return (IRepository<Entity>)GroupRepository;
            if (entityType == typeof(Student)) return (IRepository<Entity>)StudentRepository;
            if (entityType == typeof(Subject)) return (IRepository<Entity>)SubjectRepostitory;
            if (entityType == typeof(SubjectInGroup)) return (IRepository<Entity>)SubjectInGroupRepository;
            if (entityType == typeof(Teacher)) return (IRepository<Entity>)TeacherRepository;
            if (entityType == typeof(Test)) return (IRepository<Entity>)TestRepository;
            if (entityType == typeof(TestResult)) return (IRepository<Entity>)TestResultRepository;

            throw new NotSupportedException();
        }
    }
}
