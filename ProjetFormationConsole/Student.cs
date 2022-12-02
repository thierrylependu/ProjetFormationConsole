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

    public Student(string LastName, string FirstName, DateTime BirthDate, string Gender, RoleType Role, int formId, int projId, string paiement) : base(LastName, FirstName, BirthDate, Gender, Role)
    {
        this.FormationGroupId = formId;
        this.ProjectGroupId = projId;
        this.Paiement = paiement;
    }

    public Student()
    {
        FormationGroupId = -1;
        ProjectGroupId = -1;
        Paiement = "";
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "Student",
        $"IdUser, FormationGroupId, ProjectGroupId, Paiement",
        $"N'{0}', N'{FormationGroupId}', N'{ProjectGroupId}', N'{Paiement}'");
    }

    public void UpdateFormationGroup(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "FormationGroupId", FormationGroupId.ToString(), $"UserId = '{0}'");
    }
    public void UpdateProjectGroup(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "ProjectGroupId", ProjectGroupId.ToString(), $"UserId = '{0}'");
    }
    public void UpdatePaiement(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Student", "Paiement", Paiement, $"UserId = '{0}'");
    }
    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Student", $"UserId = '{0}'");
    }

    public void show()
    {
        Console.WriteLine($"nom : {LastName} {FirstName}, projet : {ProjectGroupId}, formation : {FormationGroupId}, paiement : {Paiement}");
    }
}
