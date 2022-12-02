using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationConsole;

internal class Teacher : User
{
    public int DisciplineId { get; set; }
    public string Resume { get; set; }
    public int UserId;

    public Teacher(string LastName, string FirstName, DateTime BirthDate, string Gender, int discId, string res) : base(LastName, FirstName, BirthDate, Gender)
    {
        Role = RoleType.Teacher;
        this.DisciplineId = discId;
        this.Resume = res;
    }

    public Teacher()
    {
        DisciplineId = -1;
        Resume = "";
    }
}
