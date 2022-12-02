using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Student : User
{
    public int FormationGroupId { get; set; }
    public int ProjectGroupId { get; set; }
    public string Paiement { get; set; }
    //A enlever plus tard
    public int UserId { get; set; }

    public Student(string LastName, string FirstName, DateTime BirthDate, string Gender, int formId, int projId, string paiement, int id) : base(LastName, FirstName, BirthDate, Gender)
    {
        Role = RoleType.Student;
        this.FormationGroupId = formId;
        this.ProjectGroupId = projId;
        this.Paiement = paiement;
        UserId = id;
    }

    public Student(string LastName, string FirstName, DateTime BirthDate, string Gender) : base(LastName, FirstName, BirthDate, Gender)
    {
        FormationGroupId = -1;
        ProjectGroupId = -1;
        Paiement = "";
        UserId = -1;
    }

    public Student()
    {
        FormationGroupId = -1;
        ProjectGroupId = -1;
        Paiement = "";
        UserId = -1;
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "Student",
        $"UserId, FormationGroupId, ProjectGroupId, Paiement",
        $"N'{UserId}', N'{FormationGroupId}', N'{ProjectGroupId}', N'{Paiement}'");
    }

    public void UpdateFormationGroup(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "FormationGroupId", FormationGroupId.ToString(), $"UserId = '{UserId}'");
    }
    public void UpdateProjectGroup(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "ProjectGroupId", ProjectGroupId.ToString(), $"UserId = '{UserId}'");
    }
    public void UpdatePaiement(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "Paiement", Paiement, $"UserId = '{UserId}'");
    }
    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Student", $"UserId = '{UserId}'");
    }

    public void show()
    {
        Console.WriteLine($"nom : {LastName} {FirstName}, projet : {ProjectGroupId}, formation : {FormationGroupId}, paiement : {Paiement}");
    }
}
