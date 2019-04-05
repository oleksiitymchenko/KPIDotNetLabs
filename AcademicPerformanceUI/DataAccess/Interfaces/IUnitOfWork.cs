using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Group>  GroupRepository { get; set; }
        IRepository<Student>  StudentRepository { get; set; }
        IRepository<Subject>  SubjectRepostitory { get; set; }
        IRepository<SubjectInGroup>  SubjectInGroupRepository { get; set; }
        IRepository<Teacher>  TeacherRepository { get; set; }
        IRepository<Test>  TestRepository { get; set; }
        IRepository<TestResult>  TestResultRepository { get; set; }
    }
}
