using System;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class SubjectInGroupsPage : System.Web.UI.Page
    {
        private WebClientCrudService<SubjectInGroupDto> webClient = new WebClientCrudService<SubjectInGroupDto>("SubjectInGroupService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = webClient.GetEntities();
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
                        webClient.DeleteEntity(e.CommandArgument.ToString());

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