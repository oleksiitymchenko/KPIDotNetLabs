
using DataAccess.Models;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    public class SubjectService :BaseService<SubjectDto, Subject>, ISubjectService
    {
    }
}
