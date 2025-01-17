﻿using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Bus
{
    #region statements
    private const string select = @"SELECT code AS bus_code, 
    plates AS bus_plates, capacity AS bus_capacity, status AS bus_status FROM Bus ORDER BY bus_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = "INSERT INTO Bus (plates, capacity, status) VALUES (@PLATES, @CAP, @STATUS);";
    #endregion

    #region attributes 
    private int _code;
    private string _plates;
    private int _capacity;
    private bool _status;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Plates { get => _plates; set => _plates = value; }
    public int Capacity { get => _capacity; set => _capacity = value; }
    public bool Status { get => _status; set => _status = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Bus()
    {
        _code = 0;
        _plates = "";
        _capacity = 0;
        _status = true;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public Bus(string plates, int capacity, bool status)
    {
        _plates = plates;
        _capacity = capacity;
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
    public static List<Bus> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToBusList(SqlServerConnection.ExecuteQuery(command));
    }

    public static Bus Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        Bus? br = null;
        foreach (Bus b in Get())
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
            throw new RecordNotFoundException("Bus", id);
        }
    }


    public static bool Add(Bus b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@PLATES", b.Plates);
        command.Parameters.AddWithValue("@CAP", b.Capacity);
        command.Parameters.AddWithValue("@STATUS", b.Status);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }
    #endregion
}

