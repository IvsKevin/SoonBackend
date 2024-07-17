using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Routes
{
    #region statements
    private static string select = @"SELECT code AS routes_code, 
    name AS routes_name, status AS routes_status FROM Routes ORDER BY routes_code";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _code;
    private string _name;
    private bool _status;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Name { get => _name; set => _name = value; }
    public bool Status { get => _status; set => _status = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Routes()
    {
        _code = 0;
        _name = "";
        _status = true;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public Routes(int code, string name, bool status)
    {
        _code = code;
        _name = name;
        _status = status;
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
    public static List<Routes> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToRoutesList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

