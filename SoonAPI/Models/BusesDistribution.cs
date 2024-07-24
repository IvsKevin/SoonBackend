using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BusesDistribution
{
    #region statements
    private static string select = @"SELECT route_code AS distribution_route_code, 
    bus_code AS distribution_bus_code, [day] AS distribution_day FROM BusesDistribution ORDER BY [day]";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _routes_code;
    private int _bus_code;
    private DateOnly _day;
    #endregion

    #region properties
    public int Routes { get => _routes_code; set => _routes_code = value; }
    public int Bus { get => _bus_code; set => _bus_code = value; }
    public DateOnly Day { get => _day; set => _day = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public BusesDistribution()
    {
        _routes_code = 0;
        _bus_code = 0;
        _day = DateOnly.MinValue;
    }

    public BusesDistribution(int routes_code, int bus_code, DateOnly day)
    {
        _routes_code = routes_code;
        _bus_code = bus_code;
        _day = day;
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
    /// Return a list of all the BusesDistribution
    /// </summary>
    /// <returns></returns>
    public static List<BusesDistribution> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToBusesDistributionList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

