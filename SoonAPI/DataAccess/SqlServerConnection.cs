using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

internal class SqlServerConnection
{
    #region variables
    // Connection String
    private static string cs = @"
            Data Source = IVSKEVIN\SQLEXPRESS;
            Initial Catalog = Soon;
            Integrated Security = true;
        ";
    // Connection
    private static SqlConnection? connection;
    #endregion

    #region metthods
    /// <summary>
    /// Opens a connection to a SQL Server Database
    /// </summary>
    /// <returns></returns>
    private static bool Open()
    {
        bool connected  = false;

        try
        {
            connection = new SqlConnection(cs); // Connection
            connection.Open();                  // Open connection
            connected = true;                   // Connected
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
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
        }
        return success;
    }
    #endregion
}

