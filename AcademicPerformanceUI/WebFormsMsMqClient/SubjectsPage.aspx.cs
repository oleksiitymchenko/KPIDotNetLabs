using System;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Threading;
using DataAccess.Models;
using DataAccess.Interfaces;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class SubjectsPage : System.Web.UI.Page
    {
        private readonly IRepository<Subject> Repository = Singleton.UnitOfWork.SubjectRepostitory;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = Repository.GetAllEntitiesAsync().Result;
                Repeater.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        serviceClient.RemoveSubject(e.CommandArgument.ToString());
                        scope.Complete();
                    }
                    Thread.Sleep(3000);
                    Response.Redirect("subjectspage");
                    break;

                case "Update":
                    Response.Redirect("subjectCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("subjectCreatePage");
        }
    }
}