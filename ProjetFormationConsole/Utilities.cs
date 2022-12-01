using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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

}
