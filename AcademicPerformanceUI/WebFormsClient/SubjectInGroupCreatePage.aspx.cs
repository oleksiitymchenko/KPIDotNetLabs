using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class SubjectInGroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<SubjectInGroupDto> webClientSubjectInGroup = new WebClientCrudService<SubjectInGroupDto>("SubjectInGroupService.svc");
        private WebClientCrudService<SubjectDto> webClientSubject = new WebClientCrudService<SubjectDto>("SubjectService.svc");
        private WebClientCrudService<GroupDto> webClientGroup = new WebClientCrudService<GroupDto>("GroupService.svc");
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
                    var _loadedRoute = webClientSubjectInGroup.GetEntities().Where(x => x.Id == _id).FirstOrDefault();
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

                dropdownGroup.DataSource = webClientGroup.GetEntities().Select(item => item.Id);
                dropdownSubject.DataSource = webClientSubject.GetEntities().Select(item => item.Id);
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
                webClientSubjectInGroup.CreateEntity(route);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("SubjectInGroupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = webClientSubjectInGroup.GetEntities().Where(x => x.Id == _id).FirstOrDefault();

            route.GroupId = new Guid(dropdownGroup.SelectedValue);
            route.SubjectId = new Guid(dropdownSubject.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClientSubjectInGroup.UpdateEntity(route);
                scope.Complete();
            }

            Response.Redirect("SubjectInGroupsPage");
        }
    }
}