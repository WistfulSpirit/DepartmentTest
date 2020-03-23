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
    class DepartmentController
    {
        private SqlConnection connection;

        public DepartmentController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DepartDBConnectionString"].ConnectionString);
        }

        public DepartmentController(string ConnectionString)
        {
            connection = new SqlConnection(ConnectionString);
        }

        public List<Department> GetDepartments()
        {
            var depList = new List<Department>();
            using (var com = new SqlCommand("SELECT * FROM Department", connection))
            {
                connection.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var d = new Department();
                    d.ID = (Guid)reader["ID"];
                    d.Name = (string)reader["Name"];
                    d.Code = (string)reader["Code"];
                    if (reader["ParentDepartmentID"] == DBNull.Value)
                        d.ParentDepartmentID = null;
                    else
                        d.ParentDepartmentID = (Guid)reader["ParentDepartmentID"];
                    depList.Add(d);
                }
                connection.Close();
            }
            return depList;
        }

        public List<Department> GetDepartments(Guid? ParentDepartmentID)
        {
            var depList = new List<Department>();
            string paramVal = ParentDepartmentID == null ? "is NULL" : " = '" + ParentDepartmentID.Value.ToString() + "'";

            using (var com = new SqlCommand("SELECT * FROM Department where ParentDepartmentID " + paramVal, connection))
            {
                connection.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var d = new Department();
                    d.ID = (Guid)reader["ID"];
                    d.Name = (string)reader["Name"];
                    d.Code = (string)reader["Code"];
                    if (reader["ParentDepartmentID"] == DBNull.Value)
                        d.ParentDepartmentID = null;
                    else
                        d.ParentDepartmentID = (Guid)reader["ParentDepartmentID"];
                    depList.Add(d);
                }
                connection.Close();
            }
            return depList;
        }

        public int Create(Department department)
        {
            string command = "INSERT INTO Department (ID, Name, Code, ParentDepartmentID) VALUES (@id, @name,@code,@pdID)";
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@id", department.ID);
                com.Parameters.AddWithValue("@name", department.Name);
                com.Parameters.AddWithValue("@code", department.Code);
                if (department.ParentDepartmentID == null || department.ParentDepartmentID == Guid.Empty)
                    com.Parameters.AddWithValue("@pdID", DBNull.Value);
                else
                    com.Parameters.AddWithValue("@pdID", department.ParentDepartmentID);
                connection.Open();
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public int Update(Department department)
        {
            string command = "update Department " +
                "SET Name = @name, " +
                "Code = @code," +
                "ParentDepartmentID = @pdID " +
                "where ID = @id";
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@name", department.Name);
                com.Parameters.AddWithValue("@code", department.Code);
                if (department.ParentDepartmentID == null || department.ParentDepartmentID == Guid.Empty)
                    com.Parameters.AddWithValue("@pdID", DBNull.Value);
                else
                    com.Parameters.AddWithValue("@pdID", department.ParentDepartmentID);
                com.Parameters.AddWithValue("@id", department.ID);
                connection.Open();
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }
        public int Delete(Guid id)
        {

            if (GetDaughterDepsCount(id) > 0 || GetEmpCount(id) > 0)
            {
                connection.Close();
                return -99;
            }
            var command = "Delete FROM Department where ID = @id";
            using (var com = new SqlCommand(command, connection))
            {
                connection.Open();
                com.Parameters.AddWithValue("@id", id);
                var result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        private int GetDaughterDepsCount(Guid id)
        {
            string command = "SELECT COUNT(*) as Count FROM Department WHERE ParentDepartmentID = @id";
            int deps = 0;
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@id", id);
                connection.Open();
                deps = (int)com.ExecuteScalar();
                connection.Close();
            }
            return deps;
        }

        private int GetEmpCount(Guid id)
        {
            string command = "SELECT COUNT(*) as Count FROM Empoyee WHERE DepartmentId = @id";
            int emps = 0;
            using (var com = new SqlCommand(command, connection))
            {
                com.Parameters.AddWithValue("@id", id);
                connection.Open();
                emps = (int)com.ExecuteScalar();
                connection.Close();
            }
            return emps;
        }

    }
}
