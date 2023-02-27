using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseCommand
/// </summary>
public class DatabaseCommand
{
    private SqlConnection connection;

	public DatabaseCommand()
	{

	}

    public DataTable Select(string procedure, List<InputParameter> inputParameters = null)
    {
        connection = DatabaseConnection.GetSqlConnection();

        SqlCommand command = new SqlCommand(procedure, connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        if (inputParameters != null)
        {
            foreach (InputParameter inputParameter in inputParameters)
            {
                command.Parameters.AddWithValue(inputParameter.param, inputParameter.value);
            }
        }

        DataTable dataTable = new DataTable();
        dataTable.Load(command.ExecuteReader());

        connection.Close();

        return dataTable;
    }

    public MessageStatus Save(string procedure, List<InputParameter> inputParameters = null)
    {
        connection = DatabaseConnection.GetSqlConnection();

        SqlCommand command = new SqlCommand(procedure, connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        if (inputParameters != null)
        {
            foreach (InputParameter inputParameter in inputParameters)
            {
                command.Parameters.AddWithValue(inputParameter.param, inputParameter.value);
            }
        }

        DataTable dataTable = new DataTable();
        dataTable.Load(command.ExecuteReader());

        connection.Close();

        MessageStatus messageStatus = new MessageStatus(dataTable.Rows[0].Field<string>("message"), dataTable.Rows[0].Field<bool>("message_status"));

        return messageStatus;
    }

    public DataSet SelectDataSet(string procedure, List<InputParameter> inputParameters = null)
    {
        DataSet result = new DataSet();

        connection = DatabaseConnection.GetSqlConnection();

        SqlCommand command = new SqlCommand(procedure, connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        if (inputParameters != null)
        {
            foreach (InputParameter inputParameter in inputParameters)
            {
                command.Parameters.AddWithValue(inputParameter.param, inputParameter.value);
            }
        }

        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.SelectCommand = command;

        adapter.Fill(result);

        connection.Close();

        return result;
    }
}