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

public class Civil
{
    #region statements
    private static string select = @"
    SELECT code AS civil_code, name AS civil_name, lastName AS civil_lastname, lastName2 AS civil_lastname2,
    phoneNUmber AS civil_phone, birthday AS civil_birth, [user] AS civil_user, card AS civiL_card
    FROM Civil 
    ORDER BY civil_code";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _code;
    private string? _name;
    private string? _lastname;
    private string? _lastname2;
    private string? _phone;
    private DateOnly _birthday;
    private int _user;
    private int _card;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string? Name { get => _name; set => _name = value; }
    public string? Lastname { get => _lastname; set => _lastname = value; }
    public string? Lastname2 { get => _lastname2; set => _lastname2 = value; }
    public string? Phone { get => _phone; set => _phone = value; }
    public DateOnly Birthday { get => _birthday; set => _birthday = value; }
    public int User { get => _user; set => _user = value; }
    public int Card { get => _card; set => _card = value; }

    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Civil()
    {
        Code = 0;
        Name = "";
        Lastname = "";
        Lastname2 = "";
        Phone = "";
        _birthday = DateOnly.MinValue;
        _user = 0;
        _card = 0;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>

    public Civil(int code, string name, string lastname, string lastname2, string phone, DateOnly birthday, int user, int card)
    {
        _code = code;
        _name = name;
        _lastname = lastname;
        _lastname2 = lastname2;
        _phone = phone;
        _birthday = birthday;
        _user = user;
        _card = card;
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
    public static List<Civil> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToCivilList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

