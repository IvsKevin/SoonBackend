﻿using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class User
{
    #region statements
    private static string select = "SELECT code AS user_code, email AS user_email, password AS user_password, UserType AS user_type FROM [User] ORDER BY user_code";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region attributes 
    private int _code;
    private string _email;
    private string _password;
    private int _user_tyoe;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Email { get => _email; set => _email = value; }
    public string Password { get => _password; set => _password = value; }
    public int UserType { get => _user_tyoe; set => _user_tyoe = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public User()
    {
        _code = 0;
        _email = "";
        _password = "";
        _user_tyoe = 0;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public User(int code, string email, string password, int user_type)
    {
        _code = code;
        _email = email;
        _password = password;
        _user_tyoe = user_type;
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
    public static List<User> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToUserList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}

