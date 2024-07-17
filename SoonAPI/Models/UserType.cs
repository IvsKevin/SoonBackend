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
    private static string select = @"SELECT code AS user_type_code, 
    description AS user_type_description FROM UserType ORDER BY user_type_code";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
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
    public UserType(int code, string description)
    {
        _code = code;
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
    #endregion
}

