using CrudWebService.DTOModels;
using CrudWebService.Services;
using DataAccess.Models;
using System.Web.Services;

namespace CrudWebService.WebServices
{
    /// <summary>
    /// Summary description for TestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : GenericWebService<TestDto, Test>
    {
    }
}
