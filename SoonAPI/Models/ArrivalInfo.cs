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

public class ArrivalInfo
{
    #region statements
    private const string select = @"
    SELECT station_code AS arrival_station_code, bus_code AS arrival_bus_code, 
    departureTime, arrivalTime
    FROM ArrivalInfo 
    ORDER BY arrival_bus_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = @"INSERT INTO ArrivalInfo 
    (station_code, bus_code, departureTime, arrivalTime) 
    VALUES (@STATION, @BUS, @DEPARTURE, @ARRIVAL);";
    #endregion

    #region attributes 
    private int _station;
    private int _bus;
    private DateTime _departureTime;
    private DateTime _arrivalTime;
    #endregion

    #region properties
    public int Station { get => _station; set => _station = value; }
    public int Bus { get => _bus; set => _bus = value; }
    public DateTime DepartureTime { get => _departureTime; set => _departureTime = value; }
    public DateTime ArrivalTime { get => _arrivalTime; set => _arrivalTime = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public ArrivalInfo()
    {
        _station = 0;
        _bus = 0;
        _departureTime = DateTime.Now;
        _arrivalTime = DateTime.MinValue;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public ArrivalInfo(int station, int bus, DateTime departureTime, DateTime arrivalTime)
    {
        _station = station;
        _bus = bus;
        _departureTime = departureTime;
        _arrivalTime = arrivalTime;
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
    /// Return a list of all the Civils
    /// </summary>
    /// <returns></returns>
    public static List<ArrivalInfo> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToArrivalInfoList(SqlServerConnection.ExecuteQuery(command));
    }

    public static ArrivalInfo Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        ArrivalInfo? br = null;
        foreach (ArrivalInfo b in Get())
        {
            if (b.Station == intId)
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
            throw new RecordNotFoundException("ArrivalInfo", id);
        }
    }


    public static bool Add(ArrivalInfo b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@STATION", b.Station);
        command.Parameters.AddWithValue("@BUS", b.Bus);
        command.Parameters.AddWithValue("@DEPARTURE", b.DepartureTime);
        command.Parameters.AddWithValue("@ARRIVAL", b.ArrivalTime);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }
    #endregion
}

