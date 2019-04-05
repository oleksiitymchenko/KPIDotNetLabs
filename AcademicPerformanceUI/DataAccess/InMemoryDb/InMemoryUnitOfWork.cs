using DataAccess.InMemoryDb.Repository;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;

namespace DataAccess.InMemoryDb
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private IRepository<Group> groupRepository;
        public IRepository<Group> GroupRepository => groupRepository ?? (groupRepository = new GroupRepository());

        private IRepository<Student> studentRepository;
        public IRepository<Student> StudentRepository => studentRepository ?? (studentRepository = new StudentRepository());

        private IRepository<Subject> subjectRepostitory;
        public IRepository<Subject> SubjectRepostitory => subjectRepostitory ?? (subjectRepostitory = new SubjectRepository());

        private IRepository<SubjectInGroup> subjectInGroupRepository;
        public IRepository<SubjectInGroup> SubjectInGroupRepository => subjectInGroupRepository ?? (subjectInGroupRepository = new SubjectInGroupRepository());

        private IRepository<Teacher> teacherRepository;
        public IRepository<Teacher> TeacherRepository => teacherRepository ?? (teacherRepository = new TeacherRepository());

        private IRepository<Test> testRepository;
        public IRepository<Test> TestRepository => testRepository ?? (testRepository = new TestRepository());

        private IRepository<TestResult> testResultRepository;
        public IRepository<TestResult> TestResultRepository => testResultRepository ?? (testResultRepository = new TestResultRepository());



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
