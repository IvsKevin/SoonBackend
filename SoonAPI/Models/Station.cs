﻿using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Station
{
    #region statements
    private const string select = @"SELECT code AS station_code, name AS station_name, 
    location AS station_location, status AS station_status, latitude AS station_latitude,
    longitude AS station_longitude
    FROM Stations ORDER BY station_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = @"INSERT INTO Stations (name, location, status, latitude, longitude)
        VALUES (@NAME, @LOCATION, @STATUS, @LANT, @LONG);";
    #endregion

    #region attributes 
    private int _code;
    private string _name;
    private string _location;
    private bool _status;
    private decimal? _latitude;
    private decimal? _longitude;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Name { get => _name; set => _name = value; }
    public string Location { get => _location; set => _location = value; }
    public bool Status { get => _status; set => _status = value; }
    public decimal? Latitude { get => _latitude; set => _latitude = value; }
    public decimal? Longitude { get => _longitude; set => _longitude = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Station()
    {
        _code = 0;
        _name = "";
        _location = "";
        _status = true;
        _latitude = 0;
        _longitude = 0;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public Station(string name, string location, bool status, decimal latitude, decimal longitude)
    {
        _name = name;
        _location = location;
        _status = status;
        _latitude = latitude;
        _longitude = longitude;
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
    public static List<Station> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToStationList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified Station
    /// </summary>
    /// <param name="id">Transaction id</param>
    /// <returns></returns>
    public static Station Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        Station? br = null;
        foreach (Station b in Get())
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
            throw new RecordNotFoundException("Station", id);
        }
    }

    public static bool Add(Station b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@NAME", b.Name);
        command.Parameters.AddWithValue("@LOCATION", b.Location);
        command.Parameters.AddWithValue("@STATUS", b.Status);
        command.Parameters.AddWithValue("@LANT", b.Latitude);
        command.Parameters.AddWithValue("@LONG", b.Longitude);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Update(Station b)
    {
        const string updateSql = @"UPDATE Stations SET name = @NAME, location = @LOCATION, latitude = @LANT, longitude = @LONG WHERE code = @CODE;";
        SqlCommand command = new SqlCommand(updateSql);
        command.Parameters.AddWithValue("@NAME", b.Name);
        command.Parameters.AddWithValue("@LOCATION", b.Location);
        command.Parameters.AddWithValue("@LANT", b.Latitude);
        command.Parameters.AddWithValue("@LONG", b.Longitude);
        command.Parameters.AddWithValue("@CODE", b.Code);

        return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Delete(string id)
    {
        const string deleteSql = "DELETE FROM Stations WHERE code = @CODE;";

        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        SqlCommand command = new SqlCommand(deleteSql);
        command.Parameters.AddWithValue("@CODE", intId);

        return SqlServerConnection.ExecuteNonQuery(command);
    }

    #endregion
}

