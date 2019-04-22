using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class GroupService : BaseService<GroupDto, Group>, IGroupService 
    {  
    }
}
