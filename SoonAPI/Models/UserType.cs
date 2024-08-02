using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserType
{
    #region statements
    private const string select = @"SELECT code AS user_type_code, 
    description AS user_type_description FROM UserType ORDER BY user_type_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = "INSERT INTO UserType (description) VALUES (@DESC);";
    #endregion

    #region attributes 
    private int _code;
    private string _description;

    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Description { get => _description; set => _description = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public UserType()
    {
        _code = 0;
        _description = "";
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public UserType(string description)
    {
        _description = description;
    }

    #endregion

    #region instance methods

    /// <summary>
    /// Add a new user
    /// </summary>
    /// <returns></returns>
    public bool Add()
    {
        //Add(this);
        return true;
    }

    public bool Delete()
    {
        //Remove(this);
        return true;
    }

    #endregion

    #region class methods
    /// <summary>
    /// Return a list of all the stations
    /// </summary>
    /// <returns></returns>
    public static List<UserType> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToUserTypeList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified UserType
    /// </summary>
    /// <param name="id">UserType id</param>
    /// <returns></returns>
    public static UserType Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        UserType? br = null;
        foreach (UserType b in Get())
        {
            if (b.Code == intId)
            {
                br = b;
                break;
            }
        }

        if (br != null)
        {
            return br;
        }
        else
        {
            throw new RecordNotFoundException("UserType", id);
        }
    }


    public static bool Add(UserType b)
    {
        try
        {
            // Command
            SqlCommand command = new SqlCommand(add);
            // Parameters
            command.Parameters.AddWithValue("@DESC", b.Description);
            // Execute command
            return SqlServerConnection.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding usertype: " + ex.Message);
            return false;
        }
    }
    #endregion
}

