using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_EditLogin : System.Web.UI.Page
{
    private enum CommandName
    {
        SaveCommand,
        CancelCommand
    }
    private string userId;
    public string password;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            Response.Redirect("~/Default.aspx");

        userId = Request.QueryString["user_id"];

        if (userId == string.Empty || userId == null)
            Response.Redirect("~/Default.aspx");

        LoadData();
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

    private void LoadData()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();

        string stored_procedure = "sp_select_user";

        List<InputParameter> inputs = new List<InputParameter>();

        inputs.Add(new InputParameter("@user_id", userId));

        DataTable res = dbCommand.Select(stored_procedure, inputs);

        if (res.Rows.Count > 0)
        {
            ((TextBox)EditLoginForm.FindControl("username")).Attributes["value"] = res.Rows[0].Field<string>("username");
            ((TextBox)EditLoginForm.FindControl("firstName")).Attributes["value"] = res.Rows[0].Field<string>("first_name");
            ((TextBox)EditLoginForm.FindControl("lastName")).Attributes["value"] = res.Rows[0].Field<string>("last_name");
            ((TextBox)EditLoginForm.FindControl("password")).Attributes["value"] = res.Rows[0].Field<string>("password");
            ((TextBox)EditLoginForm.FindControl("confirmPassword")).Attributes["value"] = res.Rows[0].Field<string>("password");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }


    private void SaveAction()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();

        string stored_procedure = "sp_update_login";

        List<InputParameter> inputs = new List<InputParameter>();

        inputs.Add(new InputParameter("@user_id", userId));
        inputs.Add(new InputParameter("@username", ((TextBox)EditLoginForm.FindControl("username")).Text));
        inputs.Add(new InputParameter("@firstName", ((TextBox)EditLoginForm.FindControl("firstName")).Text));
        inputs.Add(new InputParameter("@lastName", ((TextBox)EditLoginForm.FindControl("lastName")).Text));
        inputs.Add(new InputParameter("@password", ((TextBox)EditLoginForm.FindControl("password")).Text));
        inputs.Add(new InputParameter("@statusCode", ((CheckBox)EditLoginForm.FindControl("active")).Checked));
        inputs.Add(new InputParameter("@updatedBy", Session["username"].ToString()));

        MessageStatus messageStatus = dbCommand.Save(stored_procedure, inputs);

        if (messageStatus.status == true)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + messageStatus.message + "')", true);
        }
    }

    private void CancelAction()
    {
        Response.Redirect("~/Default.aspx");
    }
}