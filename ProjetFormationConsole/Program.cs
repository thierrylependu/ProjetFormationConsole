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
        DateTime d = DateTime.Now;
        User us = new User("last","first", d, "homme", User.RoleType.Student);
        us.showUser();

        SqlConnection Conn = Utilities.ConnectToSQLServer();
        us.DeleteFromDB(Conn);

        Utilities.CloseSQLServer(Conn);
    }

}