using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Utilities
{

    public static SqlConnection ConnectToSQLServer()
    {
        Console.WriteLine("Getting Connection ...");

        //var datasource = @"DESKTOP-PC\SQLEXPRESS";//your server
        var database = "ProjetFormation"; //your database name
        var username = "sa"; //username of server to connect
        var password = "password"; //password

        //your connection string 
        //string connString = @"Data Source=" + datasource + ";Initial Catalog="
        //            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
        string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;" +
            "Integrated Security=true;" +
            "Initial Catalog=" + database + ";";

        //create instanace of database connection
        SqlConnection Conn = new SqlConnection(ConnectionString);


        try
        {
            Console.WriteLine("Openning Connection ...");

            //open connection
            Conn.Open();

            Console.WriteLine("Connection successful!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return null;
        }

        return Conn;
    }

    public static void CloseSQLServer(SqlConnection Conn)
    {
        Conn.CloseAsync();
        Console.WriteLine("Fin de connection");
    }

    public static void AddToDB(SqlConnection Conn, string table, string entry, string values)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"INSERT INTO [{table}] ({entry}) VALUES ");
        strBuilder.Append($"({values}) ");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            command.ExecuteNonQuery(); //execute the Query
            Console.WriteLine("Query Executed.");
        }
    }

    public static void UpdateRow(SqlConnection Conn, string table, string row, string value, string condition)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"UPDATE [{table}] SET {row} = '{value}' WHERE {condition}");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public static void DeleteFromDB(SqlConnection Conn, string table, string condition)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"DELETE FROM [{table}] WHERE {condition}");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public static bool HasColumn(SqlDataReader data, string columnName)
    {
        for (int i = 0; i < data.FieldCount; i++)
        {
            if (data.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                return true;
        }
        return false;
    }

}
