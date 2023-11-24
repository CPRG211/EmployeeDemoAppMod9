using EmployeeDemoApp.Exceptions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Database
{
    public class SqlDatabase
    {
        private MySqlConnection sqlConnection;

        public SqlDatabase() { }

        /// <summary>
        /// Opens connection to database
        /// </summary>
        public void Open()
        {
            // Create connection string

            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();

            // The server hostname, username, password, and database name are required for a MySQL connection.
            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.UserID = "root";
            connectionStringBuilder.Password = "password";
            connectionStringBuilder.Database = "cprg211mod9demo";

            string connectionString = connectionStringBuilder.ToString();

            this.sqlConnection = new MySqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        /// <summary>
        /// Adds employee to database
        /// </summary>
        /// <param name="employee">Employee to add</param>
        public void Add(Employee employee)
        {
            // Throw exception if not connected to database.
            if (this.sqlConnection == null)
            {
                throw new NoDatabaseConnectionException();
            }

            // Create MySqlCommand instance
            MySqlCommand cmd = this.sqlConnection.CreateCommand();

            // Create the SQL statement
            // Ensure quotes are placed around string values.
            cmd.CommandText = string.Format("INSERT INTO employees VALUES({0}, '{1}', {2})", employee.Id, employee.Name, employee.IsActive ? 1 : 0);

            // Execute the SQL statement
            // Must use the "ExecuteNonQuery" method when writing to the database.
            cmd.ExecuteNonQuery();

            // Ensure the cmd resources are disposed since it's no longer used.
            cmd.Dispose();
        }

        /// <summary>
        /// Gets all employees from database
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> All()
        {
            // Throw exception if not connected to database.
            if (this.sqlConnection == null)
            {
                throw new NoDatabaseConnectionException();
            }

            // Create MySqlCommand instance
            MySqlCommand cmd = this.sqlConnection.CreateCommand();

            // Set the SQL statement
            cmd.CommandText = "SELECT * FROM employees";

            // Execute the SQL statement
            // Must use the "ExecuteReader" method when reading from the database.
            MySqlDataReader dataReader = cmd.ExecuteReader();

            // dataReader contains the results of the query.
            // The dataReader starts before the first row.

            // Create empty list that will hold retrieved employees.
            List<Employee> employees = new List<Employee>();

            // The "Read" method tries to advance to the next row.
            // It returns false if there are no more rows.
            while (dataReader.Read())
            {
                // Once in a row, we can read each cell/column in the row.

                // The appropriate Get* method needs to be used based on what the data type is for the column.
                // Example: GetString is appropriate if the SQL data type is CHAR or VARCHAR.
                // The parameter is the index of the cell (0 meaning the first cell).
                int id = dataReader.GetInt32(0);

                string name = dataReader.GetString(1);

                bool isActive = dataReader.GetBoolean(2);

                // Create employee from row data.
                Employee employee = new Employee(id, name, isActive);

                // Add employee to list.
                employees.Add(employee);
            }

            // Ensure the dataReader and cmd is closed cleanly so other commands can be done.
            dataReader.Close();
            cmd.Dispose();

            // Return retrieved employees.
            return employees;
        }

        public void Close()
        {
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection = null;
            }
        }
    }
}
