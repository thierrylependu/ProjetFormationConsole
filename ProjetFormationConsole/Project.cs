using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Project
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Technology { get; set; }

    public Project(string name, string desc, string tech)
    {
        Name = name;
        Description = desc;
        Technology = tech;
    }

    public Project(string name, string tech)
    {
        Name = name;
        Description = "";
        Technology = tech;
    }

    public Project() {
        Name = "";
        Description = "";
        Technology = "";
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "Project",
        $"Name, Description, Technology",
        $"N'{Name}', N'{Description}', N'{Technology}'");
    }

    public void UpdateDescription(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Project", "Description", Description, $"Name = '{Name}' AND Technology = '{Technology}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Project", $"Name = '{Name}' AND Technology = '{Technology}'");
    }

    public void show()
    {
        Console.WriteLine($"nom : {Name}, descritpion : {Description}, Technology : {Technology}");
    }
}
