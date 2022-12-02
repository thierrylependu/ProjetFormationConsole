using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class FormationGroup
{
    public string FormationName { get; set; }
    public int Number { get; set; }
    public DateTime FormationStart { get; set; }
    public DateTime FormationEnd { get; set; }
    public int RoomId { get; set; }
    public int DisciplineId { get; set; }

    public FormationGroup(string formationName, int number, DateTime formationStart, DateTime formationEnd, int roomId, int disciplineId)
    {
        FormationName = formationName;
        Number = number;
        FormationStart = formationStart;
        FormationEnd = formationEnd;
        RoomId = roomId;
        DisciplineId = disciplineId;
    }

    public FormationGroup(string formationName, DateTime formationStart, DateTime formationEnd, int disciplineId)
    {
        FormationName = formationName;
        Number = -1;
        FormationStart = formationStart;
        FormationEnd = formationEnd;
        RoomId = -1;
        DisciplineId = disciplineId;
    }

    public FormationGroup()
    {
        FormationName = "";
        Number = -1;
        FormationStart = DateTime.Now;
        FormationEnd = DateTime.Now;
        RoomId = -1;
        DisciplineId = -1;
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "FormationGroup",
        $"FormationName, Number, FormationStart, FormationEnd, RoomId, DisciplineId",
        $"N'{FormationName}', N'{Number}', N'{FormationStart}', N'{FormationEnd}', N'{RoomId}', N'{DisciplineId}'");
    }

    public void UpdateNumber(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "FormationGroup", "Number", Number.ToString(), $"FormationName = '{FormationName}'");
    }

    public void UpdateRoom(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "FormationGroup", "RoomId", RoomId.ToString(), $"FormationName = '{FormationName}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "FormationGroup", $"FormationName = '{FormationName}'");
    }

    public void show()
    {
        Console.WriteLine($"nom : {FormationName}, nombre : {Number}, debut : {FormationStart}, fin : {FormationEnd}, salle : {RoomId}, dicipline : {DisciplineId}");
    }
}
