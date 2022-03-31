using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeInformation
{
    internal class DB
    {
        const string DATABASE_CONNECTION_STRING = @"Server=.\SQLEXPRESS19;Database=Personnel;Trusted_Connection=True;";

        const string INSERT_COMMAND =
            "INSERT INTO Employee " +
            "(Name," +
            "Position" +
            ",PayPerHour)" +
            "VALUES " +
            "(@NAME," +
            "@POSITION," +
            "@PAYPERHOUR)";

        const string UPDATE_COMMAND =
            "UPDATE Employee " +
            "SET " +
            "Name = @NAME," +
            "Position = @POSITION," +
            "PayPerHour = @PAYPERHOUR " +
            "WHERE EmployeeID = @EMPLOYEEID";

        const string DELETE_COMMAND =
            "DELETE " +
            "FROM " +
            "Employee " +
            "WHERE EmployeeID = @EMPLOYEEID";

        const string SELECT_COMMAND =
            "SELECT" +
            "*" +
            "FROM Employee";

        const string SEARCH_COMMAND =
            "SELECT" +
            "*" +
            "FROM Employee " +
            "WHERE Name like @SEARCHKEY ";

        private readonly SqlConnection conn;

        private static DB db;

        public static DB Instance
        {
            get
            {
                db ??= new DB();
                return db;
            }
        }

        private DB()
        {
            conn = new SqlConnection(DATABASE_CONNECTION_STRING);
            conn.Open();
        }

        public bool Insert(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn);
            cmd.Parameters.AddWithValue("@NAME", employee.Name);
            cmd.Parameters.AddWithValue("@POSITION", employee.Position);
            cmd.Parameters.AddWithValue("@PAYPERHOUR", employee.PayPerHour);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@NAME", employee.Name);
            cmd.Parameters.AddWithValue("@POSITION", employee.Position);
            cmd.Parameters.AddWithValue("@PAYPERHOUR", employee.PayPerHour);
            cmd.Parameters.AddWithValue("@EMPLOYEEID", employee.EmployeeID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@EMPLOYEEID", employee.EmployeeID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            using SqlCommand cmd = new SqlCommand(SELECT_COMMAND, conn);

            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                employees.Add(new Employee
                {
                    EmployeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID")),
                    Name = dr.GetString(dr.GetOrdinal("Name")),
                    Position = dr.IsDBNull(dr.GetOrdinal("Position")) ? null : (string?)dr.GetString(dr.GetOrdinal("Position")),
                    PayPerHour = dr.IsDBNull(dr.GetOrdinal("PayPerHour")) ? null : (decimal?)dr.GetDecimal(dr.GetOrdinal("PayPerHour")),
                    IsNew = false
                });
            dr.Close();
            return employees;
        }

        public List<Employee> SearchResult(string searchKey)
        {
            List<Employee> employees = new List<Employee>();

            using SqlCommand cmd = new SqlCommand(SEARCH_COMMAND, conn);
            cmd.Parameters.AddWithValue("@SEARCHKEY", string.Format("%{0}%", searchKey.Trim()));

            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                employees.Add(new Employee
                {
                    EmployeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID")),
                    Name = dr.GetString(dr.GetOrdinal("Name")),
                    Position = dr.IsDBNull(dr.GetOrdinal("Position")) ? null : (string?)dr.GetString(dr.GetOrdinal("Position")),
                    PayPerHour = dr.IsDBNull(dr.GetOrdinal("PayPerHour")) ? null : (decimal?)dr.GetDecimal(dr.GetOrdinal("PayPerHour")),
                    IsNew = false
                });
            dr.Close();
            return employees;
        }
    }
}
