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
    public partial class SubjectCreatePage : System.Web.UI.Page
    {
        private SubjectDto _loadedSubject;
        private Guid _id;
        private List<SubjectDto> GetEntities()
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


        private void CreateEntity(SubjectDto subjectDto)
        {
            string site = FormsSettings.HostUrl + "SubjectService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "POST";

            var data = JsonConvert.SerializeObject(subjectDto);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            req.ContentType = "application/json";
            req.ContentLength = byteArray.Length;
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
                CreateEntity(subject);

                scope.Complete();
            }

            Thread.Sleep(3000);


            Response.Redirect("subjects");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //var list = _wcfClient.GetEntities();
            //var subject = list.Where(sub => sub.Id == _id).FirstOrDefault();
            //subject.Name = subjectName.Text;
            //subject.Hours = int.Parse(subjectHours.Text);
            //Enum.TryParse(subjectTestType.Text, out FinalTestType rang);
            //subject.FinalTestType = rang;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {

             //   _wcfClient.UpdateEntity(subject);

                scope.Complete();
            }

            // repo.Update(driver);

            Response.Redirect("subjects");
        }
    }
}