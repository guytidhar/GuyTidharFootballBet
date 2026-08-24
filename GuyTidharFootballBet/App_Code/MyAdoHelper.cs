using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class MyAdoHelper
{
    private static string ConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["FootballBetConnectionString"].ConnectionString;
    }

    public static DataTable ExecuteDataTable(string sql)
    {
        DataTable table = new DataTable();
        SqlConnection connection = new SqlConnection(ConnectionString());
        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
        adapter.Fill(table);
        return table;
    }

    public static bool IsExist(string sql)
    {
        DataTable table = ExecuteDataTable(sql);
        return table.Rows.Count > 0;
    }

    public static void DoQuery(string sql)
    {
        SqlConnection connection = new SqlConnection(ConnectionString());
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    // Overload matching examples commonly used in class.
    public static void DoQuery(string dbName, string sql)
    {
        DoQuery(sql);
    }

    public static string FixText(string value)
    {
        if (value == null) return "";
        return value.Trim().Replace("'", "''");
    }
}