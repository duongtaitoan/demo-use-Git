using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Employee
    {
        public Employee(string empID, string empPass, string empRole)
        {
            EmpID = empID;
            EmpPass = empPass;
            EmpRole = empRole;
        }

        public string EmpID { get; set; }
        public string EmpPass { get; set; }
        public string EmpRole { get; set; }
    }
}
