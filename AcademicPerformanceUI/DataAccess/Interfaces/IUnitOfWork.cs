using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Group>  GroupRepository { get; }
        IRepository<Student>  StudentRepository { get; }
        IRepository<Subject>  SubjectRepostitory { get; }
        IRepository<SubjectInGroup>  SubjectInGroupRepository { get; }
        IRepository<Teacher>  TeacherRepository { get; }
        IRepository<Test>  TestRepository { get;  }
        IRepository<TestResult>  TestResultRepository { get; }

        IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity;
    }
}
