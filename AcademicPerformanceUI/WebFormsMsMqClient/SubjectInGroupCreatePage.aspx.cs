using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class SubjectInGroupCreatePage : System.Web.UI.Page
    {
        private readonly IRepository<Subject> SubjectRepository = Singleton.UnitOfWork.SubjectRepostitory;
        private readonly IRepository<Group> GroupRepository = Singleton.UnitOfWork.GroupRepository;
        private readonly IRepository<SubjectInGroup> SubjectInGroupRepository = Singleton.UnitOfWork.SubjectInGroupRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        private Guid _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedRoute = SubjectInGroupRepository.GetAllEntitiesAsync().Result.Where(x => x.Id == _id).FirstOrDefault();
                    dropdownGroup.SelectedValue = _loadedRoute.GroupId.ToString();
                    dropdownSubject.SelectedValue = _loadedRoute.SubjectId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update subject in group";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new subject in group";
                }

                dropdownGroup.DataSource = GroupRepository.GetAllEntitiesAsync().Result.Select(item => item.Id);
                dropdownSubject.DataSource = SubjectRepository.GetAllEntitiesAsync().Result.Select(item => item.Id);
                DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var route = new SubjectInGroupDto();
            route.Id = Guid.NewGuid();
            route.GroupId = new Guid(dropdownGroup.SelectedValue);
            route.SubjectId = new Guid(dropdownSubject.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(route);
                serviceClient.CreateSiG(serialized);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("SubjectInGroupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = SubjectInGroupRepository.GetAllEntitiesAsync().Result.Where(x => x.Id == _id).FirstOrDefault();

            route.GroupId = new Guid(dropdownGroup.SelectedValue);
            route.SubjectId = new Guid(dropdownSubject.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(route);
                serviceClient.UpdateSiG(serialized);
                scope.Complete();
            }

            Response.Redirect("SubjectInGroupsPage");
        }
    }
}