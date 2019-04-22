using System.ServiceModel;
using System.ServiceModel.Web;
using WcfRestService.DTOModels;

namespace WcfRestService.ServiceInterfaces
{
    [ServiceContract]
    public interface IGroupService : IBaseService<GroupDto>
    {
    }

    [ServiceContract]
    public interface IStudentService : IBaseService<StudentDto>
    {
    }

    [ServiceContract]
    public interface ISubjectService : IBaseService<SubjectDto>
    {
    }

    [ServiceContract]
    public interface ISubjectInGroupService : IBaseService<SubjectInGroupDto>
    {
    }

    [ServiceContract]
    public interface ITeacherService : IBaseService<TeacherDto>
    {
    }

    [ServiceContract]
    public interface ITestService : IBaseService<TestDto>
    {
    }

    [ServiceContract]
    public interface ITestResultService : IBaseService<TestResultDto>
    {
    }
}
