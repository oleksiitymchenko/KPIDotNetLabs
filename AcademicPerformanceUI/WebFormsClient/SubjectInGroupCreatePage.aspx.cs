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
    public partial class SubjectInGroupCreatePage : System.Web.UI.Page
    {
        private List<SubjectInGroupDto> GetEntities()
        {
            string site = FormsSettings.HostUrl + "SubjectInGroupService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<SubjectInGroupDto>>(text);
        }

        private List<GroupDto> GetEntities2()
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

        private List<SubjectDto> GetEntities1()
        {
            string site = FormsSettings.HostUrl + "SubjectService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<SubjectDto>>(text);
        }

        private void UpdateEntity(SubjectInGroupDto subjectDto)
        {
            string site = FormsSettings.HostUrl + "SubjectInGroupService.svc/Entities";

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
                    var _loadedRoute = GetEntities().Where(x => x.Id == _id).FirstOrDefault();
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

                dropdownGroup.DataSource = GetEntities2();
                dropdownSubject.DataSource = GetEntities1();
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

                UpdateEntity(route);

                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("SubjectInGroupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = GetEntities().Where(x => x.Id == _id).FirstOrDefault();

            route.GroupId = new Guid(dropdownGroup.SelectedValue);
            route.SubjectId = new Guid(dropdownSubject.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                UpdateEntity(route);
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