using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Indisponibility
{

    public int TeacherId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Indisponibility(int teacherId, DateTime date, string description)
    {
        TeacherId = teacherId;
        Date = date;
        Description = description;
    }

    public Indisponibility(int teacherId, DateTime date)
    {
        TeacherId = teacherId;
        Date = date;
        Description = "";
    }
    public Indisponibility()
    {
        TeacherId = -1;
        Date = DateTime.Now;
        Description = "";
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "Indisponibility",
        $"TeacherId, Date, Description",
        $"N'{TeacherId}', N'{Date}', N'{Description}'");
    }

    public void UpdateDescription(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Indisponibility", "Description", Description, $"TeacherId = '{TeacherId}' AND Date = '{Date}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Indisponibility", $"TeacherId = '{TeacherId}' AND Date = '{Date}'");
    }

    public void show()
    {
        Console.WriteLine($"prof : {TeacherId}, date : {Date}, description : {Description}");
    }
}
