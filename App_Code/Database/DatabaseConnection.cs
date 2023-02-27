using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DatabaseConnection
{
    private static SqlConnection con;

    public static SqlConnection GetSqlConnection()
    {
        if (con == null)
        {
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }

        return con;
    }

    private DatabaseConnection()
    {

    }
}