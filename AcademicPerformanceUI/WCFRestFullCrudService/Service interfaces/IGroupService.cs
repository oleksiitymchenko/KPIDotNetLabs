using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFRestFullCrudService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGroupService<TEntity>
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "Group",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<TEntity> GetEntities();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "Group",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        TEntity CreateEntity(TEntity entity);

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
        bool UpdateEntity(TEntity entity);
    }
}
