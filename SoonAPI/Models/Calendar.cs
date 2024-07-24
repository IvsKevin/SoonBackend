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
using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Routing;

public class Calendar
{
    #region statements
    private static string select = @"
    SELECT driver_code AS calendar_driver_code, bus_code AS calendar_bus_code,
    [day] AS calendar_day
    FROM Calendar 
    ORDER BY [day]";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _driver;
    private int _bus;
    private DateOnly _day;
    #endregion

    #region properties
    public int Driver { get => _driver; set => _driver = value; }
    public int Bus { get => _bus; set => _bus = value; }
    public DateOnly Day { get => _day; set => _day = value; }

    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Calendar()
    {
        Driver = 0;
        Bus = 0;
        Day = DateOnly.MinValue;
    }

    public Calendar(int driver, int bus, DateOnly day)
    {
        Driver = driver;
        Bus = bus;
        Day = day;
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
    /// Return a list of all the Calendar
    /// </summary>
    /// <returns></returns>
    public static List<Calendar> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToCalendarList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

