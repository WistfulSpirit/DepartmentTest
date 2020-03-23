using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departments.Models;
using Departments.Controllers;
using System.ComponentModel;

namespace Departments
{
    public static class Data
    {
        public static List<Department> departmentsList { get; set; }
        public static Department department { get; set; }
        public static Employee employee { get; set; }
    }
}
