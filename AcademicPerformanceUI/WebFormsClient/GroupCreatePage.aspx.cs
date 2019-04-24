using System;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class GroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<GroupDto> webClient = new WebClientCrudService<GroupDto>("GroupService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["Id"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedSubject = webClient.GetEntities().Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

                    groupName.Text = _loadedSubject.GroupName;
                    groupMaxStudents.Text = _loadedSubject.MaxStudents.ToString();
                    groupStudyYear.Text = _loadedSubject.StudyYear.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update group";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new group";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            GroupDto subject = new GroupDto();
            subject.GroupName = groupName.Text;
            subject.MaxStudents = int.Parse(groupMaxStudents.Text);
            subject.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.CreateEntity(subject);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = webClient.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            group.GroupName = groupName.Text;
            group.MaxStudents = int.Parse(groupMaxStudents.Text);
            group.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.UpdateEntity(group);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}