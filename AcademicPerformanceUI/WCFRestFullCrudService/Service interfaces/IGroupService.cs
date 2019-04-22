using System.ServiceModel;
using System.ServiceModel.Web;
using WCFRestFullCrudService.DTOModels;

namespace WCFRestFullCrudService
{
    [ServiceContract]
    public interface IGroupService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "Groups",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        string GetEntities();
        //List<Group> GetEntities();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "Group",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Group CreateEntity(Group entity);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "Group",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        bool DeleteEntity(string id);

        [OperationContract]
        [WebInvoke(
           Method = "PUT",
           UriTemplate = "Group",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        bool UpdateEntity(Group entity);
    }
}
