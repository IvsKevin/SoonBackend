using System;
using System.Data;
using System.Data.SqlClient;

internal class SqlServerConnection
{
    #region variables
    // Connection String
    private const string cs = @"
        Server=tcp:soon-api-server.database.windows.net,1433;
        Initial Catalog=SoonDB2;
        Persist Security Info=False;
        User ID=soon_adminitrador1;
        Password=administrador09_;
        MultipleActiveResultSets=False;
        Encrypt=True;
        TrustServerCertificate=False;
        Connection Timeout=30;
    ";

    // private const string cs = @"
    //     Data Source = IVSKEVIN\SQLEXPRESS;
    //     Initial Catalog = Soon;
    //     Integrated Security = true;";

    // Connection
    private static SqlConnection? connection;
    #endregion

    #region methods
    /// <summary>
    /// Opens a connection to a SQL Server Database
    /// </summary>
    /// <returns></returns>
    private static bool Open()
    {
        bool connected = false;

        try
        {
            connection = new SqlConnection(cs); // Connection
            connection.Open();                  // Open connection
            connected = true;                   // Connected
            Console.WriteLine("Connection opened successfully.");

            // Get and print the list of tables
            ListTables();
        }
        catch (SqlException e)
        {
            Console.WriteLine("SQL Exception: " + e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Argument Exception: " + e.Message);
        }

        return connected;
    }

    /// <summary>
    /// Executes a SQL query 
    /// </summary>
    /// <param name="command">Data Table</param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(SqlCommand command)
    {
        DataTable table = new DataTable(); // Data table

        if (Open())
        {
            try
            {
                // Assign connection to command
                command.Connection = connection;
                // Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                // Execute query and populate data table
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection?.Close();
            }
        }
        return table;
    }

    public static bool ExecuteNonQuery(SqlCommand command)
    {
        bool success = false;

        if (Open())
        {
            try
            {
                // Assign connection to command
                command.Connection = connection;
                // Execute statement
                command.ExecuteNonQuery();
                // Success
                success = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection?.Close();
            }
        }
        return success;
    }

    /// <summary>
    /// Lists all tables in the database
    /// </summary>
    private static void ListTables()
    {
        string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Tables in the database:");
                while (reader.Read())
                {
                    Console.WriteLine(reader["TABLE_NAME"]);
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine("SQL Exception: " + e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Argument Exception: " + e.Message);
        }
    }
    #endregion
}
