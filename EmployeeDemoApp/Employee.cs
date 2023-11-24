using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemoApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public Employee(int id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}
