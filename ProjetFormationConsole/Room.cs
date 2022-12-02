using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Room
{





    public string Name { get; set; }
    public string Building { get; set; }
    public int Floor { get; set; }
    public bool Occuped { get; set; }
    public int Capacity { get; set; }


    public Room(string Name, string Building, int Floor, bool Occuped, int Capacity)
    {
        this.Name = Name;
        this.Building = Building;
        this.Floor = Floor;
        this.Occuped = Occuped;
        this.Capacity = Capacity;
    }

    public Room()
    {
        this.Name = "";
        this.Building = "";
        this.Floor = 0;
        this.Occuped = false;
        this.Capacity = 30;
    }

    public void AddToDB(SqlConnection Conn)
    {
        int occ = Occuped ? 1 : 0;
        Utilities.AddToDB(Conn,
            "Room",
            $"Name, Building, Floor, Occuped, Capacity",
            $"N'{Name}', N'{Building}', N'{Floor.ToString()}', N'{occ.ToString()}', N'{Capacity.ToString()}'");
    }

    public void UpdateName(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Room", "Name", this.Name, $"Name = '{Name}'");
    }

    public void UpdateBuilding(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Room", "Building", this.Building, $"Name = '{Name}'");

    }

    public void UpdateFloor(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Room", "Floor", this.Floor.ToString(), $"Name = '{Name}'");
    }


    public void UpdateOccuped(SqlConnection Conn)
    {
        int occ = Occuped ? 1 : 0;
        Utilities.UpdateRow(Conn, "Room", "Occuped", occ.ToString(), $"Name = '{Name}'");
    }

    public void UpdateCapacity(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Room", "Capacity", this.Capacity.ToString(), $"Name = '{Name}'");
    }



    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Room", $"Name = '{Name}'");
    }

    public void show()
    {
        Console.WriteLine($"La salle : {Name} , située au : {Building},  de capacité : {Capacity}, est:  {Occuped}");
    }

}
