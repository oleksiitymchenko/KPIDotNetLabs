using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class GroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private readonly IRepository<Group> Repository = Singleton.UnitOfWork.GroupRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
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
                    var _loadedSubject = Repository.GetAllEntitiesAsync().Result.Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

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
            Group subject = new Group();
            subject.Id = Guid.NewGuid();
            subject.GroupName = groupName.Text;
            subject.MaxStudents = int.Parse(groupMaxStudents.Text);
            subject.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(subject);
                serviceClient.CreateGroup(serialized);
                scope.Complete();
            }
            Thread.Sleep(3000);

            Response.Redirect("groupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();
            group.GroupName = groupName.Text;
            group.MaxStudents = int.Parse(groupMaxStudents.Text);
            group.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(group);

                serviceClient.UpdateGroup(serialized);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}