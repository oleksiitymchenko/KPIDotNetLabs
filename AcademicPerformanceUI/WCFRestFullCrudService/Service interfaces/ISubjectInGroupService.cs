using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFRestFullCrudService
{
    [ServiceContract]
    public interface ISubjectInGroupService<TEntity>
    {
        [OperationContract]
        [WebInvoke(
           Method = "GET",
           UriTemplate = "SubjectInGroup",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        List<TEntity> GetEntities();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "SubjectInGroup",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        TEntity CreateEntity(TEntity entity);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "SubjectInGroup",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        bool DeleteEntity(string id);

        [OperationContract]
        [WebInvoke(
           Method = "PUT",
           UriTemplate = "SubjectInGroup",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        bool UpdateEntity(TEntity entity);
    }
}
