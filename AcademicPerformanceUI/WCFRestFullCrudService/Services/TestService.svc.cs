using WCFRestFullCrudService.DTOModels;

namespace WCFRestFullCrudService
{
    public class TestService :BaseService<Test>, ITestService<Test>
    {
    }
}
