using System;
using System.ComponentModel;

namespace Departments.Models
{
    public class Department
    {
        public Guid ID { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Код")]
        public string Code { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        public Department(){}
    }
}
