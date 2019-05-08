using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class GroupsPage : System.Web.UI.Page
    {
        private readonly IRepository<Group> Repository = Singleton.UnitOfWork.GroupRepository;
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
                        serviceClient.RemoveGroup(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Response.Redirect("groupspage");
                    break;
                case "Update":
                    Response.Redirect("groupCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("groupCreatePage");
        }
}
}