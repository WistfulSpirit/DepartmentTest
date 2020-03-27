using Departments.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments.Controllers
{
    class EmployeeController
    {
        private SqlConnection connection;

        public EmployeeController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DepartDBConnectionString"].ConnectionString);
        }

        public EmployeeController(string ConnectionString)
        {
            connection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Returns all employees list
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployee()
        {
            var empList = new List<Employee>();
            using (var com = new SqlCommand("SELECT * FROM Empoyee", connection))
            {
                connection.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var d = new Employee();
                    d.ID = Decimal.ToInt32((decimal)reader["ID"]);
                    d.FirstName = (string)reader["Name"];
                    d.SurName = (string)reader["SurName"];
                    d.Patronymic = (string)reader["Patronymic"];
                    d.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    d.Patronymic = (string)reader["DocSeries"];
                    d.Patronymic = (string)reader["DocNumber"];
                    d.Patronymic = (string)reader["Position"];
                    d.DepartmentID = (Guid)reader["DepartmentID"];
                    empList.Add(d);
                }
                connection.Close();
            }
            return empList;
        }

        public List<Employee> GetEmployee(Guid DepartmentID)
        {
            var empList = new List<Employee>();
            using (var com = new SqlCommand($"SELECT * FROM Empoyee WHERE DepartmentID = '{DepartmentID}'", connection))
            {
                connection.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var d = new Employee();
                    d.ID = Decimal.ToInt32((decimal)reader["ID"]);
                    d.FirstName = (string)reader["FirstName"];
                    d.SurName = (string)reader["SurName"];
                    d.Patronymic = reader["Patronymic"] == DBNull.Value ? "" : (string)reader["Patronymic"];
                    d.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    d.Age = GetAge(d.DateOfBirth);
                    d.DocSeries = (string)reader["DocSeries"];
                    d.DocNumber = (string)reader["DocNumber"];
                    d.Position = (string)reader["Position"];
                    d.DepartmentID = (Guid)reader["DepartmentID"];
                    empList.Add(d);
                }
                connection.Close();
            }
            return empList;
        }

        public int Create(Employee employee)
        {
            string command = "INSERT INTO Empoyee (FirstName, SurName, Patronymic, DateOfBirth, DocSeries, DocNumber, Position, DepartmentID)" +
                "VALUES (@FirstName, @SurName, @Patronymic, @DateOfBirth, @DocSeries, @DocNumber, @Position, @DepartmentID)";
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@FirstName", employee.FirstName);
                com.Parameters.AddWithValue("@SurName", employee.SurName);
                com.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                com.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth.Date);
                com.Parameters.AddWithValue("@DocSeries", employee.DocSeries);
                com.Parameters.AddWithValue("@DocNumber", employee.DocNumber);
                com.Parameters.AddWithValue("@Position", employee.Position);
                com.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
                connection.Open();
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public int Update(Employee employee)
        {
            string command = "update Empoyee SET " +
                "FirstName= @FirstName, SurName=@SurName, Patronymic = @Patronymic, " +
                "DateOfBirth = @DateOfBirth, " +
                "DocSeries = @DocSeries, DocNumber = @DocNumber, Position = @Position, " +
                "DepartmentID = @DepartmentID " +
                "where ID = @id";
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@FirstName", employee.FirstName);
                com.Parameters.AddWithValue("@SurName", employee.SurName);
                com.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                com.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth.Date);
                com.Parameters.AddWithValue("@DocSeries", employee.DocSeries);
                com.Parameters.AddWithValue("@DocNumber", employee.DocNumber);
                com.Parameters.AddWithValue("@Position", employee.Position);
                com.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
                com.Parameters.AddWithValue("@id", employee.ID);
                connection.Open();
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public int Delete(int id)
        {
            var command = "Delete FROM Empoyee where ID = @id";
            using (var com = new SqlCommand(command, connection))
            {
                connection.Open();
                com.Parameters.AddWithValue("@id", id);
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        private int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;
            if (now.DayOfYear <= birthday.DayOfYear)
                age--;
            return age;
        }
    }
}
