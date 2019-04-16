using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.SqlDbConnection.Repositories;
using System;
using System.Data.SqlClient;

namespace DataAccess.SqlDbConnection
{
    public class SqlDbConnectionUnitOfWork : IUnitOfWork
    {
        protected SqlConnection SqlConnection;
        public SqlDbConnectionUnitOfWork(string connectionString)
        {
            SqlConnection = new SqlConnection(connectionString);
        }
        private IRepository<Group> groupRepository;
        public IRepository<Group> GroupRepository => groupRepository ?? (groupRepository = new GroupRepository(SqlConnection));

        private IRepository<Student> studentRepository;
        public IRepository<Student> StudentRepository => studentRepository ?? (studentRepository = new StudentRepository(SqlConnection));

        private IRepository<Subject> subjectRepostitory;
        public IRepository<Subject> SubjectRepostitory => subjectRepostitory ?? (subjectRepostitory = new SubjectRepository(SqlConnection));

        private IRepository<SubjectInGroup> subjectInGroupRepository;
        public IRepository<SubjectInGroup> SubjectInGroupRepository => subjectInGroupRepository ?? (subjectInGroupRepository = new SubjectInGroupRepository(SqlConnection));

        private IRepository<Teacher> teacherRepository;
        public IRepository<Teacher> TeacherRepository => teacherRepository ?? (teacherRepository = new TeacherRepository(SqlConnection));

        private IRepository<Test> testRepository;
        public IRepository<Test> TestRepository => testRepository ?? (testRepository = new TestRepository(SqlConnection));

        private IRepository<TestResult> testResultRepository;
        public IRepository<TestResult> TestResultRepository => testResultRepository ?? (testResultRepository = new TestResultRepository(SqlConnection));



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
