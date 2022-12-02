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

        //User us = new User("last","first", d, "homme", User.RoleType.Student);
        //us.showUser();
        //us.AddToDB(Conn);
        //us.Role = User.RoleType.Teacher;
        //us.Password = "test";
        //us.Picture = "road";
        //us.UpdatePassword(Conn);
        //us.UpdatePicture(Conn);
        //us.UpdateRole(Conn);
        //us.DeleteFromDB(Conn);

        //FormationGroup f = new FormationGroup("LS",1,d,d,1,1);
        //f.show();
        //f.AddToDB(Conn);
        //f.RoomId= 5;
        //f.UpdateRoom(Conn);
        //f.DeleteFromDB(Conn);

        //HistoricTeacher h = new HistoricTeacher(1, d,d,"truc");
        //h.show();
        //h.AddToDB(Conn);
        //h.Description = "t";
        //h.UpdateDescription(Conn);
        //h.DeleteFromDB(Conn);

        //Indisponibility i = new Indisponibility(1, d);
        //i.show();
        //i.AddToDB(Conn);
        //i.Description = "truc";
        //i.UpdateDescription(Conn);
        //i.DeleteFromDB(Conn);

        //Presence p = new Presence(1, d, false);
        //p.show();
        //p.AddToDB(Conn);
        //p.IsPresent = true;
        //p.UpdatePresence(Conn);
        //p.DeleteFromDB(Conn);

        //Project p = new Project("test", "info");
        //p.show();
        //p.AddToDB(Conn);
        //p.Description= "desc";
        //p.UpdateDescription(Conn);
        //p.DeleteFromDB(Conn);

        //ProjectGroup p = new ProjectGroup("ls");
        //p.show();
        //p.AddToDB(Conn);
        //p.Number = 100;
        //p.ProjectId = 5;
        //p.UpdateNumber(Conn);
        //p.UpdateProjectId(Conn);
        //p.DeleteFromDB(Conn);

        //Report r = new Report(10, 20, "test", d);
        //r.show();
        //r.AddToDB(Conn);
        //r.Grade = 0;
        //r.UpdateGrade(Conn);
        //r.DeleteFromDB(Conn);

        Room r = new Room("name", "8 rue du machin", 2, false, 20);
        //r.AddToDB(Conn);
        //r.Building = "7";
        //r.Capacity = 8;
        //r.Floor = 4;
        //r.Occuped = true;
        //r.UpdateBuilding(Conn);
        //r.UpdateCapacity(Conn);
        //r.UpdateFloor(Conn);
        //r.UpdateOccuped(Conn);
        r.DeleteFromDB(Conn);


        Utilities.CloseSQLServer(Conn);
    }

}