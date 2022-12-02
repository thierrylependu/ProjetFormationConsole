using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class HistoricTeacher
{
    public int TeacherId { get; set; }
    public DateTime EmployementStart { get; set; }
    public DateTime EmployementEnd { get; set; }
    public string Description { get; set; }

    public HistoricTeacher(int teacherId, DateTime employementStart, DateTime employementEnd, string description)
    {
        TeacherId = teacherId;
        EmployementStart = employementStart;
        EmployementEnd = employementEnd;
        Description = description;
    }

    public HistoricTeacher(int teacherId, DateTime employementStart, DateTime employementEnd)
    {
        TeacherId = teacherId;
        EmployementStart = employementStart;
        EmployementEnd = employementEnd;
        Description = "";
    }
    public HistoricTeacher()
    {
        TeacherId = -1;
        EmployementStart = DateTime.Now;
        EmployementEnd = DateTime.Now;
        Description = "";
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "HistoricTeacher",
        $"TeacherId, EmployementStart, EmployementEnd,Description",
        $"N'{TeacherId}', N'{EmployementStart}', N'{EmployementEnd}', N'{Description}'");
    }

    public void UpdateDescription(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "HistoricTeacher", "Description", Description, $"TeacherId = '{TeacherId}' AND EmployementStart = '{EmployementStart}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "HistoricTeacher", $"TeacherId = '{TeacherId}' AND EmployementStart = '{EmployementStart}'");
    }

    public void show()
    {
        Console.WriteLine($"prof : {TeacherId}, date de debut : {EmployementStart}, date de fin : {EmployementEnd}, description : {Description}");
    }
}
