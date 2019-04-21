using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.LinqToSql.Repositories;
using System;

namespace DataAccess.LinqToSql
{
    public class LinqToSqlUnitOfWork:IUnitOfWork
    {
        protected string ConnectionString;
        public LinqToSqlUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private IRepository<Group> groupRepository;
        public IRepository<Group> GroupRepository => groupRepository ?? (groupRepository = new GroupRepository(ConnectionString));

        private IRepository<Student> studentRepository;
        public IRepository<Student> StudentRepository => studentRepository ?? (studentRepository = new StudentRepository(ConnectionString));

        private IRepository<Subject> subjectRepostitory;
        public IRepository<Subject> SubjectRepostitory => subjectRepostitory ?? (subjectRepostitory = new SubjectRepository(ConnectionString));

        private IRepository<SubjectInGroup> subjectInGroupRepository;
        public IRepository<SubjectInGroup> SubjectInGroupRepository => subjectInGroupRepository ?? (subjectInGroupRepository = new SubjectInGroupRepository(ConnectionString));

        private IRepository<Teacher> teacherRepository;
        public IRepository<Teacher> TeacherRepository => teacherRepository ?? (teacherRepository = new TeacherRepository(ConnectionString));

        private IRepository<Test> testRepository;
        public IRepository<Test> TestRepository => testRepository ?? (testRepository = new TestRepository(ConnectionString));

        private IRepository<TestResult> testResultRepository;
        public IRepository<TestResult> TestResultRepository => testResultRepository ?? (testResultRepository = new TestResultRepository(ConnectionString));

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
