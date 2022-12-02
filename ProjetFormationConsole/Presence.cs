using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Presence
{

    public int StudentId { get; set; }
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }

    public Presence(int studentId, DateTime date, bool isPresent)
    {
        StudentId = studentId;
        Date = date;
        IsPresent = isPresent;
    }

    public Presence()
    {
        StudentId = 0;
        Date = DateTime.Now;
        IsPresent = false;
    }

    public void AddToDB(SqlConnection Conn)
    {
        int pres = IsPresent ? 1 : 0;
        Utilities.AddToDB(Conn,
            "Presence",
        $"StudentId, IsPresent, Date",
        $"N'{StudentId}', N'{pres}', N'{Date}'");
    }

    public void UpdatePresence(SqlConnection Conn)
    {
        int pres = IsPresent ? 1 : 0;
        Utilities.UpdateRow(Conn, "Presence", "IsPresent", pres.ToString(), $"StudentId = '{StudentId}' AND Date = '{Date}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Presence", $"StudentId = '{StudentId}' AND Date = '{Date}'");
    }

    public void show()
    {
        Console.WriteLine($"etudiant : {StudentId}, date : {Date}, presence : {IsPresent}");
    }
}
