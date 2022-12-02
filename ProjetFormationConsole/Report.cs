using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Report
{

    public int StudentId { get; set; }
    public int Grade { get; set; }
    public string TypeOfExam { get; set; }
    public DateTime Date { get; set; }


    public Report(int id, int grade, string exam, DateTime date) {
        StudentId = id;
        Grade = grade;
        TypeOfExam = exam;
        Date = date;
    }

    public Report()
    {
        StudentId = -1;
        Grade = 0;
        TypeOfExam = "";
        Date = DateTime.Now;
    }

    public void AddToDB(SqlConnection Conn)
    {
        Utilities.AddToDB(Conn,
            "Report",
        $"StudentId, Grade, TypeOfExam, Date",
        $"N'{StudentId}', N'{Grade}', N'{TypeOfExam}', N'{Date}'");
    }

    public void UpdateGrade(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Report", "Grade", this.Grade.ToString(), $"StudentId = '{StudentId}' AND Date = '{Date}' AND TypeOfExam = '{TypeOfExam}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Report", $"StudentId = '{StudentId}' AND Date = '{Date}' AND TypeOfExam = '{TypeOfExam}'");
    }

    public void show()
    {
        Console.WriteLine($"etudiant : {StudentId}, date : {Date}, exam : {TypeOfExam}, note : {Grade}");
    }
}
