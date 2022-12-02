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

    public enum RoleType { Student, Teacher }

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

    public User(string LastName, string FirstName, DateTime BirthDate, string Gender)
    {
        this.LastName = LastName;
        this.FirstName = FirstName;
        this.BirthDate = BirthDate;
        this.Gender = Gender;
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

    public void AddUserToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "User",
            $"LastName, FirstName, BirthDate, Gender, Role, UserName, Password",
            $"N'{LastName}', N'{FirstName}', N'{BirthDate}', N'{Gender}', N'{Role.ToString()}', N'{UserName}', N'{Password}'");
    }

    public void UpdatePassword(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "User", "Password", this.Password, $"Username = '{UserName}'");
    }

    public void UpdateRole(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "User", "Role", this.Role.ToString(), $"Username = '{UserName}'");

    }

    public void UpdatePicture(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "User", "Picture", this.Picture, $"Username = '{UserName}'");
    }

    public void DeleteUserFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "User", $"UserName = '{UserName}'");
    }

    public void showUser()
    {
        Console.WriteLine($"nom : {LastName} {FirstName}, date : {BirthDate}, genre : {Gender}, img : {Picture}, login: {UserName} {Password}, role : {Role}");
    }

}
