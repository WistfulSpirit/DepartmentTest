using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments.Models
{
    public class Employee
    {
        [Browsable(false)]
        public int ID { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string SurName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Серия документов")]
        public string DocSeries { get; set; }
        [DisplayName("Номер документов")]
        public string DocNumber { get; set; }
        [DisplayName("Должность")]
        public string Position { get; set; }
       
        [Browsable(false)]
        public Guid DepartmentID { get; set; }

        public Employee(){}
    }
}
