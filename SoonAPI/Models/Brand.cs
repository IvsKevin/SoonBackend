using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Brand : Catalog
{
    #region statements
    private static string select = "SELECT id AS brand_id, description AS brand_description FROM brands ORDER BY brand_description";
    private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private static string add = "INSERT INTO brands (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Brand()
    {
        _id = "";
        _description = "";
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public Brand(string id, string description)
    {
        _id = id;
        _description = description;
    }

    #endregion

    #region instance methods

    /// <summary>
    /// Add a new brand
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
    /// Return a list of all the brands
    /// </summary>
    /// <returns></returns>
    public static List<Brand> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToBrandList(SqlServerConnection.ExecuteQuery(command));     
    }

    /// <summary>
    /// Returns the specified brand
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <returns></returns>
    public static Brand Get(string id)
    {
        Brand br = new Brand();
        bool found = false;

        foreach (Brand b in Get())
        {
            if (b.Id == id)
            {
                found = true;
                br = b;
            }
        }
        if (found)
        {
            return br;
        }
        else
            throw new RecordNotFoundException("Brand", id);
    }

    public static bool Add(Brand b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@ID", b.Id);
        command.Parameters.AddWithValue("@DESC", b.Description);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }
    #endregion
}

