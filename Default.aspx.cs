using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private enum CommandName
    {
        AddNewLoginCommand,
        LogoutCommand,
        EditCommand,
        ExportCommand
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            ToLoginPage();

        LoadReportTypes();
        
        LoadData();
    }

    private void LoadReportTypes()
    {
        ReportTypes.Items.Add(new ListItem("PDF", "1"));
        ReportTypes.Items.Add(new ListItem("XLS", "2"));
        ReportTypes.Items.Add(new ListItem("CLV", "3"));
    }


    protected void ButtonOnClick(Object sender, CommandEventArgs e)
    {
        CommandName commandName = (CommandName)Enum.Parse(typeof(CommandName), e.CommandName, true);
        switch (commandName)
        {
            case CommandName.AddNewLoginCommand:
                AddNewLoginAction();
                break;

            case CommandName.LogoutCommand:
                LogoutAction();
                break;

            case CommandName.EditCommand:
                Button button = (Button)sender;
                EditAction(button.CommandArgument.ToString());
                break;

            case CommandName.ExportCommand:
                ExportAction();
                break;
        }
    }

    private void LoadData()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();

        string stored_procedure = "sp_select_users";

        DataTable res = dbCommand.Select(stored_procedure);

        if (res.Rows.Count > 0)
        {
            users.DataSource = res;
            users.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Available')", true);
        }
    }

    private void AddNewLoginAction()
    {
        Response.Redirect("~/Account/NewLogin.aspx");
    }

    private void LogoutAction()
    {
        Session.Clear();

        ToLoginPage();
    }

    private void EditAction(String user_id)
    {
        Response.Redirect("~/Account/EditLogin.aspx?user_id=" + user_id);
    }


    private void ToLoginPage()
    {
        Response.Redirect("~/Account/Login.aspx");
    }

    private void ExportAction()
    {
        DatabaseCommand dbCommand = new DatabaseCommand();
        string stored_procedure = "sp_select_users_report";

        DataSet res = dbCommand.SelectDataSet(stored_procedure);

        ReportDocument reportDocument = new ReportDocument();
        reportDocument.Load(Server.MapPath("~/UserReport.rpt"));
        reportDocument.SetDataSource(res.Tables["Table"]);

        ReportViewer.ReportSource = reportDocument;

        ExportFormatType selectedType = GetSelectedReportType();

        reportDocument.ExportToHttpResponse(selectedType, Response, false, "Users Information");
    }

    private ExportFormatType GetSelectedReportType()
    {
        ExportFormatType selectedType = ExportFormatType.PortableDocFormat;

        switch (ReportTypes.SelectedValue)
        {
            case "1":
                selectedType = ExportFormatType.PortableDocFormat;
                break;

            case "2":
                selectedType = ExportFormatType.ExcelWorkbook;
                break;

            case "3":
                selectedType = ExportFormatType.CharacterSeparatedValues;
                break;

        }

        return selectedType;
    }


}