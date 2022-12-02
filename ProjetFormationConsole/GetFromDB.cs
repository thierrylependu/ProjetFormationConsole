using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ProjetFormationConsole.User;

namespace ProjetFormationConsole;

internal class GetFromDB
{

    public static User GetUserFromDB(SqlConnection Conn, string UserName)
    {
        User res = new User();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [User] WHERE UserName = '{UserName}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                res.LastName = SQLReader["LastName"].ToString();
                res.FirstName = SQLReader["FirstName"].ToString();
                string birthyear = SQLReader["BirthDate"].ToString();
                res.Gender = SQLReader["Gender"].ToString();
                string role = SQLReader["Role"].ToString();
                string picture = SQLReader["Picture"].ToString();
                res.UserName = SQLReader["UserName"].ToString();
                res.Password = SQLReader["Password"].ToString();
                User.RoleType Role;
                if (role == "Student")
                {
                    Role = User.RoleType.Student;
                }
                else
                {
                    Role = User.RoleType.Teacher;

                }
                res.Role = Role;
                DateTime Date = DateTime.Parse(birthyear);
                res.BirthDate = Date;
                if (picture != "")
                {
                    res.Picture = picture;
                }
            }
            SQLReader.Close();

        }
        return res;
    }



    public static Student GetStudentFromDB(SqlConnection Conn, string UserName, int id)
    {
        User user = GetUserFromDB(Conn, UserName);
        Student res = new Student(user.LastName, user.FirstName, user.BirthDate, user.Gender);
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Student] WHERE UserId = '{id}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                string idS = "";
                idS = SQLReader["UserId"].ToString();
                int usId = 0;
                int.TryParse(idS, out usId);
                res.UserId = usId;
                res.Paiement = SQLReader["Paiement"].ToString();
                string dateS = SQLReader["Date"].ToString();
                DateTime Date = DateTime.Parse(dateS);
                string idGF = "";
                idS = SQLReader["FormationGroupId"].ToString();
                int usGF = 0;
                int.TryParse(idS, out usGF);
                res.FormationGroupId = usGF;
                string idGP = "";
                idS = SQLReader["ProjectGroupId"].ToString();
                int usGP = 0;
                int.TryParse(idS, out usGP);
                res.ProjectGroupId = usGP;
            }
            SQLReader.Close();

        }

        return res;
    }

    public static List<Report> GetReportFromDB(SqlConnection Conn, int StudentId)
    {
        List<Report> res = new List<Report>();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Report] WHERE StudentId = '{StudentId}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                Report report = new Report();
                string idS = "";
                idS = SQLReader["StudentId"].ToString();
                int id = 0;
                int.TryParse(idS, out id);
                report.StudentId = id;
                report.TypeOfExam = SQLReader["TypeOfExam"].ToString();
                string dateS = SQLReader["Date"].ToString();
                DateTime Date = DateTime.Parse(dateS);
                report.Date = Date;
                string gradeS = "";
                gradeS = SQLReader["Grade"].ToString();
                int grade = 0;
                int.TryParse(idS, out grade);
                report.Grade = grade;
                res.Add(report);
            }
            SQLReader.Close();

        }
        return res;
    }

    public static List<Presence> GetPresenceFromDB(SqlConnection Conn, int StudentId)
    {
        List<Presence> res = new List<Presence>();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Presence] WHERE StudentId = '{StudentId}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                Presence pres = new Presence();
                string idS = "";
                idS = SQLReader["StudentId"].ToString();
                int id = 0;
                int.TryParse(idS, out id);
                pres.StudentId = id;
                string dateS = SQLReader["Date"].ToString();
                DateTime Date = DateTime.Parse(dateS);
                pres.Date = Date;
                string isPres = "";
                isPres = SQLReader["IsPresent"].ToString();

                pres.IsPresent = isPres == "1" ? true : false;
                res.Add(pres);
            }
            SQLReader.Close();

        }
        return res;
    }

    public static Project GetProjectFromDB(SqlConnection Conn, string name, string tech)
    {
        Project res = new Project();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Project] WHERE Name = '{name}' AND Technology = '{tech}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                res.Name = SQLReader["Name"].ToString();
                res.Technology = SQLReader["Technology"].ToString();
                string desc = SQLReader["Description"].ToString();
                if (desc != "")
                {
                    res.Description = desc;
                }
            }
            SQLReader.Close();

        }
        return res;
    }

    public static ProjectGroup GetProjectGroupFromDB(SqlConnection Conn, string name)
    {
        ProjectGroup res = new ProjectGroup();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [ProjectGroup] WHERE Name = '{name}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                res.Name = SQLReader["Name"].ToString();
                string num = SQLReader["Number"].ToString();
                string projId = SQLReader["ProjectId"].ToString();
                if (num != "")
                {
                    int n;
                    int.TryParse(num, out n);
                    res.Number = n;
                }
                if (projId != "")
                {
                    int n;
                    int.TryParse(projId, out n);
                    res.ProjectId = n;
                }
            }
            SQLReader.Close();

        }
        return res;
    }

    public static FormationGroup GetFormationGroupFromDB(SqlConnection Conn, string name)
    {
        FormationGroup res = new FormationGroup();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [FormationGroup] WHERE FormationName = '{name}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                res.FormationName = SQLReader["FormationName"].ToString();
                string dateSt = SQLReader["FormationStart"].ToString();
                DateTime Date = DateTime.Parse(dateSt);
                res.FormationStart = Date;
                string dateEn = SQLReader["FormationEnd"].ToString();
                Date = DateTime.Parse(dateEn);
                res.FormationEnd = Date;
                string num = SQLReader["Number"].ToString();
                string roomId = SQLReader["RoomId"].ToString();
                string discId = SQLReader["DisciplineId"].ToString();
                if (num != "")
                {
                    int n;
                    int.TryParse(num, out n);
                    res.Number = n;
                }
                if (roomId != "")
                {
                    int n;
                    int.TryParse(roomId, out n);
                    res.RoomId = n;
                }
                if (discId != "")
                {
                    int n;
                    int.TryParse(discId, out n);
                    res.DisciplineId = n;
                }
            }
            SQLReader.Close();

        }
        return res;
    }

    public static Indisponibility GetIndisponibilityFromDB(SqlConnection Conn, int id, DateTime date)
    {
        Indisponibility res = new Indisponibility();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Indisponibility] WHERE TeacherId = '{id}' AND Date = '{date}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                int teach = 0;
                string t = SQLReader["TeacherId"].ToString();
                int.TryParse(t, out teach);
                res.TeacherId = teach;
                string dateS = SQLReader["Date"].ToString();
                DateTime Date = DateTime.Parse(dateS);
                res.Date = Date;
                string desc = SQLReader["Description"].ToString();
                if (desc != "")
                {
                    res.Description = desc;
                }
            }
            SQLReader.Close();

        }
        return res;
    }

    public static HistoricTeacher GetHistoricTeacherFromDB(SqlConnection Conn, int id, DateTime date)
    {
        HistoricTeacher res = new HistoricTeacher();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [HistoricTeacher] WHERE TeacherId = '{id}' AND EmployementStart = '{date}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                int teach = 0;
                string t = SQLReader["TeacherId"].ToString();
                int.TryParse(t, out teach);
                res.TeacherId = teach;
                string dateS = SQLReader["EmployementStart"].ToString();
                DateTime Date = DateTime.Parse(dateS);
                res.EmployementStart = Date;
                string dateE = SQLReader["EmployementEnd"].ToString();
                Date = DateTime.Parse(dateE);
                res.EmployementEnd = Date;
                string desc = SQLReader["Description"].ToString();
                if (desc != "")
                {
                    res.Description = desc;
                }
            }
            SQLReader.Close();

        }
        return res;
    }

    public static Room GetRoomFromDB(SqlConnection Conn, string name)
    {
        Room res = new Room();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Room] WHERE Name = '{name}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                int cap = 0;
                string c = SQLReader["Capacity"].ToString();
                int.TryParse(c, out cap);
                res.Capacity = cap;
                int flo = 0;
                string f = SQLReader["Floor"].ToString();
                int.TryParse(f, out flo);
                res.Floor = flo;
                res.Name = SQLReader["Name"].ToString();
                res.Building = SQLReader["Building"].ToString();
                string occ = SQLReader["Occuped"].ToString();
                bool occuped = occ == "1";
                res.Occuped = occuped;

            }
            SQLReader.Close();

        }
        return res;
    }

    public static Equipment GetEquipmentFromDB(SqlConnection Conn, string name)
    {
        Equipment res = new Equipment();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Equipment] WHERE Name = '{name}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                int quant = 0;
                string q = SQLReader["Quantity"].ToString();
                int.TryParse(q, out quant);
                res.Quantity = quant;
                res.Name = SQLReader["Name"].ToString();
                string mov = SQLReader["Movable"].ToString();
                bool movable = (mov == "1");
                res.Movable = movable;

            }
            SQLReader.Close();

        }
        return res;
    }

    public static Discipline GetDisciplineFromDB(SqlConnection Conn, string name)
    {
        Discipline res = new Discipline();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append($"SELECT * FROM [Discipline] WHERE Name = '{name}'");
        string sqlQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                res.Name = SQLReader["Name"].ToString();
            }
            SQLReader.Close();

        }
        return res;
    }

}
