using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class GroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private List<GroupDto> GetEntities()
        {
            string site = FormsSettings.HostUrl + "GroupService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<GroupDto>>(text);
        }

        private void CreateEntity(GroupDto subjectDto)
        {
            subjectDto.Id = Guid.NewGuid();
            string site = FormsSettings.HostUrl + "GroupService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "POST";

            var data = JsonConvert.SerializeObject(subjectDto);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

            req.ContentType = "application/json";
            req.ContentLength = byteArray.Length;

            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
        }

        private void UpdateEntity(GroupDto subjectDto)
        {
            string site = FormsSettings.HostUrl + "GroupService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "PUT";

            var data = JsonConvert.SerializeObject(subjectDto);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            req.ContentType = "application/json";
            req.ContentLength = byteArray.Length;

            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
        }

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
                    var _loadedSubject = GetEntities().Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

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
                CreateEntity(subject);

                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("groupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            group.GroupName = groupName.Text;
            group.MaxStudents = int.Parse(groupMaxStudents.Text);
            group.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {

                UpdateEntity(group);

                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}