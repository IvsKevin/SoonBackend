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

public class RouteStation
{
    #region statements
    private const string select = @"
    SELECT route_code, station_code
    FROM RouteStations 
    ORDER BY route_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = "INSERT INTO RouteStations (route_code, station_code) VALUES (@ROUTE, @STATION);";
    #endregion

    #region attributes 
    private int _route;
    private int _station;
    #endregion

    #region properties
    public int Route { get => _route; set => _route = value; }
    public int Station { get => _station; set => _station = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public RouteStation()
    {
        _route = 0;
        _station = 0;
    }

    public RouteStation(int route, int station)
    {
        _route = route;
        _station = station;
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
    /// Return a list of all the RouteStations
    /// </summary>
    /// <returns></returns>
    public static List<RouteStation> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToRouteStationList(SqlServerConnection.ExecuteQuery(command));
    }

    public static RouteStation Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        RouteStation? br = null;
        foreach (RouteStation b in Get())
        {
            if (b.Route == intId)
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
            throw new RecordNotFoundException("Station", id);
        }
    }

    public static bool Add(RouteStation b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@ROUTE", b.Route);
        command.Parameters.AddWithValue("@STATION", b.Station);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }
    #endregion
}

