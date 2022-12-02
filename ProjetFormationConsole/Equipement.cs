using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Equipment
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public bool Movable { get; set; }



    public Equipment(string Name, int Quantity, bool Movable)
    {
        this.Name = Name;
        this.Quantity = Quantity;
        this.Movable = Movable;
    }

    public Equipment()
    {
        this.Name = "";
        this.Quantity = 0;
        this.Movable = true;
    }

    public void AddToDB(SqlConnection Conn)
    {
        int IsMovable = Movable ? 1 : 0;
        Utilities.AddToDB(Conn,
            "Equipment",
            $"Name, Quantity, Movable",
            $"N'{Name}', N'{Quantity.ToString()}', N'{IsMovable.ToString()}'");
    }

    public void UpdateName(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Equipment", "Name", this.Name, $"Name = '{Name}'");
    }

    public void UpdateQuantity(SqlConnection Conn)
    {
        Utilities.UpdateRow(Conn, "Equipment", "Quantity", this.Quantity.ToString(), $"Name = '{Name}'");

    }

    public void UpdateMovable(SqlConnection Conn)
    {
        int IsMovable = Movable ? 1 : 0;
        Utilities.UpdateRow(Conn, "Equipment", "Movable", IsMovable.ToString(), $"Name = '{Name}'");
    }

    public void DeleteFromDB(SqlConnection Conn)
    {
        Utilities.DeleteFromDB(Conn, "Equipment", $"Name = '{Name}'");
    }

    public void show()
    {
        string IsMovable = !Movable ? "Fixe" : "Mobil";
        Console.WriteLine($"Il y a : {Quantity} , {Name}, {IsMovable}");
    }

}
