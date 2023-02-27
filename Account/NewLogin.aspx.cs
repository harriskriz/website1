using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_NewLogin : System.Web.UI.Page
{
    private enum CommandName
    {
        SaveCommand,
        CancelCommand
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            Response.Redirect("~/Account/Login.aspx");
    }

    protected void ButtonOnClick(Object sender, CommandEventArgs e)
    {
        CommandName commandName = (CommandName)Enum.Parse(typeof(CommandName), e.CommandName, true);
        switch (commandName)
        {
            case CommandName.SaveCommand:
                SaveAction();
                break;

            case CommandName.CancelCommand:
                CancelAction();
                break;
        }
    }

    private void SaveAction()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();

        string stored_procedure = "sp_insert_new_login";

        List<InputParameter> inputs = new List<InputParameter>();

        inputs.Add(new InputParameter("@username", ((TextBox)NewLoginForm.FindControl("username")).Text));
        inputs.Add(new InputParameter("@firstName", ((TextBox)NewLoginForm.FindControl("firstName")).Text));
        inputs.Add(new InputParameter("@lastName", ((TextBox)NewLoginForm.FindControl("lastName")).Text));
        inputs.Add(new InputParameter("@password", ((TextBox)NewLoginForm.FindControl("password")).Text));
        inputs.Add(new InputParameter("@statusCode", ((CheckBox)NewLoginForm.FindControl("active")).Checked));
        inputs.Add(new InputParameter("@createdBy", Session["username"].ToString()));

        MessageStatus messageStatus = dbCommand.Save(stored_procedure, inputs);

        if (messageStatus.status == true)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+messageStatus.message+"')", true);
        }
    }

    private void CancelAction()
    {
        Response.Redirect("~/Default.aspx");
    }
}