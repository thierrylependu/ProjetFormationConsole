using Microsoft.Data.SqlClient;
using ProjetFormationConsole;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFormationConsole;

public class Program
{


    public static void Main()
    {
        SqlConnection Conn = Utilities.ConnectToSQLServer();
        DateTime d = DateTime.Now;

        //User us = new User("last", "first", d, "homme", User.RoleType.Student);
        //us.showUser();
        //us.AddUserToDB(Conn);
        //us.Role = User.RoleType.Teacher;
        //us.Password = "test";
        //us.Picture = "road";
        //us.UpdatePassword(Conn);
        //us.UpdatePicture(Conn);
        //us.UpdateRole(Conn);
        //User us2 = GetFromDB.GetUserFromDB(Conn, "lastfirst");
        //us2.showUser();
        //us.DeleteUserFromDB(Conn);

        //FormationGroup f = new FormationGroup("LS", 1, d, d, 1, 1);
        //f.show();
        //f.AddToDB(Conn);
        //f.RoomId = 5;
        //f.UpdateRoom(Conn);
        //FormationGroup f2 = GetFromDB.GetFormationGroupFromDB(Conn, "LS");
        //f2.show();
        //f.DeleteFromDB(Conn);

        //HistoricTeacher h = new HistoricTeacher(1, d, d, "truc");
        //h.show();
        //h.AddToDB(Conn);
        //h.Description = "t";
        //h.UpdateDescription(Conn);
        //HistoricTeacher h2 = GetFromDB.GetHistoricTeacherFromDB(Conn, 1, d);
        //h2.show();
        //h.DeleteFromDB(Conn);

        //Indisponibility i = new Indisponibility(1, d);
        //i.show();
        //i.AddToDB(Conn);
        //i.Description = "truc";
        //i.UpdateDescription(Conn);
        //Indisponibility i2 = GetFromDB.GetIndisponibilityFromDB(Conn, 1, d);
        //i2.show();
        //i.DeleteFromDB(Conn);

        //Presence p = new Presence(1, d, false);
        //p.show();
        //p.AddToDB(Conn);
        //p.IsPresent = true;
        //p.UpdatePresence(Conn);
        //List<Presence> p2 = GetFromDB.GetPresenceFromDB(Conn, 1);
        //p2[0].show();
        //p.DeleteFromDB(Conn);

        //Project p = new Project("test", "info");
        //p.show();
        //p.AddToDB(Conn);
        //p.Description = "desc";
        //p.UpdateDescription(Conn);
        //Project p2 = GetFromDB.GetProjectFromDB(Conn, "test", "info");
        //p.DeleteFromDB(Conn);

        //ProjectGroup p = new ProjectGroup("ls");
        //p.show();
        //p.AddToDB(Conn);
        //p.Number = 100;
        //p.ProjectId = 5;
        //p.UpdateNumber(Conn);
        //p.UpdateProjectId(Conn);
        //ProjectGroup p2 = GetFromDB.GetProjectGroupFromDB(Conn, "ls");
        //p2.show();
        //p.DeleteFromDB(Conn);

        //Report r = new Report(10, 20, "test", d);
        //r.show();
        //r.AddToDB(Conn);
        //r.Grade = 0;
        //r.UpdateGrade(Conn);
        //Report r2 = GetFromDB.GetReportFromDB(Conn, 10)[0];
        //r2.show();
        //r.DeleteFromDB(Conn);

        //Room r = new Room("name", "8 rue du machin", 2, false, 20);
        //ref.show();
        //r.AddToDB(Conn);
        //r.Building = "7";
        //r.Capacity = 8;
        //r.Floor = 4;
        //r.Occuped = true;
        //r.UpdateBuilding(Conn);
        //r.UpdateCapacity(Conn);
        //r.UpdateFloor(Conn);
        //r.UpdateOccuped(Conn);
        //Room r2 = GetFromDB.GetRoomFromDB(Conn, "name");
        //r2.show();
        //r.DeleteFromDB(Conn);

        //Equipment e = new Equipment("test", 5, false);
        //e.show();
        //e.AddToDB(Conn);
        //e.Quantity = 10;
        //e.Movable = true;
        //e.UpdateQuantity(Conn);
        //e.UpdateMovable(Conn);
        //Equipment e2 = GetFromDB.GetEquipmentFromDB(Conn, "test");
        //e2.show();
        //e.DeleteFromDB(Conn);

        //Discipline di = new Discipline("info");
        //di.show();
        //di.AddToDB(Conn);
        //Discipline di2 = GetFromDB.GetDisciplineFromDB(Conn, "info");
        //di2.show();
        //di.DeleteFromDB(Conn);

        Student s = new Student("last","first",d,"homme", 5, 4, "IDF", 1);
        s.AddUserToDB(Conn);
        s.AddToDB(Conn);
        s.show();
        s.FormationGroupId = 50;
        s.ProjectGroupId = 41;
        s.Password = "test";
        s.UpdateFormationGroup(Conn);
        s.UpdatePaiement(Conn);
        s.UpdateProjectGroup(Conn);
        s.UpdatePassword(Conn);
        s.DeleteUserFromDB(Conn);
        s.DeleteFromDB(Conn);

        Utilities.CloseSQLServer(Conn);
    }

}