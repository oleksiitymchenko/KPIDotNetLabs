using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class SubjectInGroupsPage : System.Web.UI.Page
    {
        private readonly IRepository<SubjectInGroup> SubjectInGroupRepository = Singleton.UnitOfWork.SubjectInGroupRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = SubjectInGroupRepository.GetAllEntitiesAsync().Result;
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
                        serviceClient.RemoveSiG(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Thread.Sleep(3000);
                    Response.Redirect("subjectingroupspage");
                    break;
                case "Update":
                    Response.Redirect("subjectingroupCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("subjectingroupCreatePage");
        }
    }
}