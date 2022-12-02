using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Discipline
{
    public string Name { get; set; }




    public Discipline(string Name)
    {
        this.Name = Name;
    }

    public Discipline()
    {
        this.Name = "";
    }

    //public void DisciplineInsert(string Name)
    //{
    //    this.Name = " ";
    //}

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
        "Discipline",
        $"Name",
        $"N'{Name}'");
    }

    public void UpdateName(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Discipline", "Name", this.Name, $"Name = '{Name}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Discipline", $"Name = '{Name}'");
    }

    public void show()
    {
        Console.WriteLine($"C'est la discipline : {Name}");
    }

}

