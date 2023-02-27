using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
    private enum CommandName
    {
        LoginCommand,
        RegisterCommand
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ButtonOnClick(Object sender, CommandEventArgs e)
    {
        CommandName commandName = (CommandName)Enum.Parse(typeof(CommandName), e.CommandName, true);
        switch (commandName)
        {
            case CommandName.LoginCommand:
                LoginAction();
                break;
        }
    }

    private void LoginAction()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();

        string stored_procedure = "sp_login";

        List<InputParameter> inputs = new List<InputParameter>();

        inputs.Add(new InputParameter("@username", ((TextBox)LoginForm.FindControl("username")).Text));
        inputs.Add(new InputParameter("@password", ((TextBox)LoginForm.FindControl("password")).Text));

        DataTable res = dbCommand.Select(stored_procedure, inputs);

        if (res.Rows.Count > 0)
        {
            string user_id = res.Rows[0].Field<string>("user_id");
            if (user_id != null && user_id != string.Empty)
            {
                Session["username"] = ((TextBox)LoginForm.FindControl("username")).Text;
                Session["user_id"] = res.Rows[0].Field<string>("user_id");
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                string message = res.Rows[0].Field<string>("message");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ message +"')", true);
            }
        }
    }
}