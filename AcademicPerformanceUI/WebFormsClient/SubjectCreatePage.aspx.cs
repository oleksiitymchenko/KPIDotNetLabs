using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class SubjectCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private string serviceName = "SubjectService.svc";
        private WebClientCrudService<SubjectDto> client = new WebClientCrudService<SubjectDto>();
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
                    var _loadedSubject = client.GetEntities(serviceName).Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

                    subjectName.Text = _loadedSubject.Name;
                    subjectHours.Text = _loadedSubject.Hours.ToString();
                    subjectTestType.Text = _loadedSubject.FinalTestType.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update subject";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new subject";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SubjectDto subject = new SubjectDto();

            subject.Name = subjectName.Text;
            subject.Hours = int.Parse(subjectHours.Text);
            Enum.TryParse(subjectTestType.Text, out FinalTestType rang);
            subject.FinalTestType = rang;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.CreateEntity(serviceName,subject);

                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("subjectsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var subject = client.GetEntities(serviceName).Where(sub => sub.Id == _id).FirstOrDefault();
            subject.Name = subjectName.Text;
            subject.Hours = int.Parse(subjectHours.Text);
            Enum.TryParse(subjectTestType.Text, out FinalTestType rang);
            subject.FinalTestType = rang;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.UpdateEntity(serviceName,subject);
                scope.Complete();
            }

            Response.Redirect("subjectsPage");
        }
    }
}