using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Security.Cryptography;

namespace ProjetFormationConsole;

internal class User
{

    public enum RoleType { Student, Teacher}

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public string Picture { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }


    public User(string LastName, string FirstName, DateTime BirthDate, string Gender, RoleType Role)
    {
        this.LastName = LastName;
        this.FirstName = FirstName;
        this.BirthDate = BirthDate;
        this.Gender = Gender;
        this.Role = Role;
        this.UserName = LastName + FirstName;
        this.Password = LastName + BirthDate.ToShortDateString();
    }

    public User()
    {
        this.LastName = "";
        this.FirstName = "";
        this.BirthDate = DateTime.Now;
        this.Gender = "";
        this.Role = RoleType.Student;
        this.UserName = LastName;
        this.Password = LastName;
    }

    public void AddToDB(SqlConnection Conn)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append("INSERT INTO [User] (LastName, FirstName, BirthDate, Gender, Role, UserName, Password) VALUES ");
        strBuilder.Append($"(N'{LastName}', N'{FirstName}', N'{BirthDate}', N'{Gender}', N'{Role.ToString()}', N'{UserName}', N'{Password}') ");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            command.ExecuteNonQuery(); //execute the Query
            Console.WriteLine("Query Executed.");
        }
    }

    public void UpdatePassword(SqlConnection Conn)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"UPDATE [User] SET Password = '{Password}' WHERE UserName = '{UserName}'");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public void UpdateRole(SqlConnection Conn)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"UPDATE [User] SET Role = '{Role}' WHERE UserName = '{UserName}'");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public void UpdatePicture(SqlConnection Conn)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"UPDATE [User] SET Picture = '{Picture}' WHERE UserName = '{UserName}'");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"DELETE FROM [User] WHERE UserName = '{UserName}'");
        string sqlQuery = strBuilder.ToString();
        sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            SQLReader.Close();
        }
    }

    public void showUser()
    {
        Console.WriteLine($"nom : {LastName} {FirstName}, date : {BirthDate}, genre : {Gender}, img : {Picture}, login: {UserName} {Password}, role : {Role}");
    }

}
