using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Xml.Linq;

public class Driver
{
    #region statements
    private const string select = @"
    SELECT code AS driver_code, name AS driver_name, lastName AS driver_lastname, lastName2 AS driver_lastname2,
    phoneNUmber AS driver_phone, assignedBus AS driver_bus, [user] AS driver_user
    FROM Driver 
    ORDER BY driver_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    //private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _code;
    private string _name;
    private string _lastname;
    private string _lastname2;
    private string _phone;
    private int _bus;
    private int _user;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Name { get => _name; set => _name = value; }
    public string Lastname { get => _lastname; set => _lastname = value; }
    public string Lastname2 { get => _lastname2; set => _lastname2 = value; }
    public string Phone { get => _phone; set => _phone = value; }
    public int Bus { get => _bus; set => _bus = value; }
    public int User { get => _user; set => _user = value; }

    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Driver()
    {
        _code = 0;
        _name = "";
        _lastname = "";
        _lastname2 = "";
        _phone = "";
        _bus = 0;
        _user = -0;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>

    public Driver(int code, string name, string lastname, string lastname2, string phone, int bus, int user)
    {
        _code = code;
        _name = name;
        _lastname = lastname;
        _lastname2 = lastname2;
        _phone = phone;
        _bus = bus;
        _user = user;
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
    /// Return a list of all the users
    /// </summary>
    /// <returns></returns>
    public static List<Driver> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToDriverList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

