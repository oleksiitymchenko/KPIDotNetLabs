using System;
using System.Web.UI.WebControls;
using System.Transactions;
using WcfRestService.DTOModels;
using System.Threading;

namespace WebFormsClient
{
    public partial class SubjectsPage : System.Web.UI.Page
    {
        private WebClientCrudService<SubjectDto> client = new WebClientCrudService<SubjectDto>("SubjectService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = client.GetEntities();
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
                        client.DeleteEntity(e.CommandArgument.ToString());
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