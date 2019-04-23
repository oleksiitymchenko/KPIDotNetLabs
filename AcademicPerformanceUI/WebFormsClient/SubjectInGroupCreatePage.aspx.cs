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
        private string serviceName = "SubjectInGroup.svc";
        private WebClientCrudService<SubjectInGroupDto> webClientSubjectInGroup = new WebClientCrudService<SubjectInGroupDto>();
        private WebClientCrudService<SubjectDto> webClientSubject = new WebClientCrudService<SubjectDto>();
        private WebClientCrudService<GroupDto> webClientGroup = new WebClientCrudService<GroupDto>();
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
                    var _loadedRoute = webClientSubjectInGroup.GetEntities(serviceName).Where(x => x.Id == _id).FirstOrDefault();
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

                dropdownGroup.DataSource = webClientGroup.GetEntities(serviceName).Select(item => item.Id);
                dropdownSubject.DataSource = webClientSubject.GetEntities(serviceName).Select(item => item.Id);
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
                webClientSubjectInGroup.CreateEntity(serviceName, route);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("SubjectInGroupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = webClientSubjectInGroup.GetEntities(serviceName).Where(x => x.Id == _id).FirstOrDefault();

            route.GroupId = new Guid(dropdownGroup.SelectedValue);
            route.SubjectId = new Guid(dropdownSubject.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClientSubjectInGroup.UpdateEntity(serviceName,route);
                scope.Complete();
            }

            Response.Redirect("SubjectInGroupsPage");
        }

        protected void dropdown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void dropdown_OnSelectedIndexChanged1(object sender, EventArgs e)
        {
        }
    }
}