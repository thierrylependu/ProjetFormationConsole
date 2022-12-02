using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class ProjectGroup
{

    public string Name { get; set; }
    public int Number { get; set; }
    public int ProjectId { get; set; }

    public ProjectGroup(string name, int number, int projectId)
    {
        Name = name;
        Number = number;
        ProjectId = projectId;
    }

    public ProjectGroup(string name)
    {
        Name = name;
        Number = -1;
        ProjectId = -1;
    }

    public ProjectGroup()
    {
        Name = "";
        Number = -1;
        ProjectId = -1;
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "ProjectGroup",
        $"Name, Number, ProjectId",
        $"N'{Name}', N'{Number}', N'{ProjectId}'");
    }

    public void UpdateNumber(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "ProjectGroup", "Number", Number.ToString(), $"Name = '{Name}'");
    }

    public void UpdateProjectId(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "ProjectGroup", "ProjectId", ProjectId.ToString(), $"Name = '{Name}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "ProjectGroup", $"Name = '{Name}'");
    }

    public void show()
    {
        Console.WriteLine($"nom : {Name}, nombre : {Number}, projet : {ProjectId}");
    }


}
