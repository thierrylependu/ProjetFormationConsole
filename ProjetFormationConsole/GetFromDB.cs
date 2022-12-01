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

}
