using Dapper;
using DotNetCoreWebAPIWithDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithDapper.Repository
{
    public class EmployeeRepository
    {
        private string connectionString;
        public EmployeeRepository()
        {
            connectionString = "Data Source=LT-78\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO Employee (Name, City)"
                                + " VALUES(@Name, @City)";
                dbConnection.Open();
                dbConnection.Execute(query, employee);
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Employee>("SELECT * FROM Employee");
            }
        }

        public Employee GetEmployeeByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM Employee"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Employee>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "DELETE FROM Employee"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(query, new { Id = id });
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "UPDATE Employee SET Name = @Name,"
                               + " City = @City "
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(query, employee);
            }
        }
    }
}
