using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.Models
{
    public partial class Client
    {
        public string FIO => FirstName + " " + LastName + " " + Patronymic;
    }
}
