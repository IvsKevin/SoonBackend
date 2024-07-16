using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Category : Catalog
{
    #region statements
    private static string select = "SELECT id AS category_id, description AS category_description FROM category ORDER BY category_description";
    private static string selecOne = "SELECT id AS category_id, description AS category_description FROM category WHERE id = @ID";
    private static string add = "INSERT INTO category (id, description) VALUES (@ID, @DESC);";
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Category()
        {
            _id = "";
            _description = "";
        }

        /// <summary>
        /// Creates an object with values from the arguments
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <param name="description">Brand description</param>
        public Category(string id, string description)
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
        //data.Add(this);
        return true;
    }

    public bool Delete()
    {
        //data.Remove(this);
        return true;
    }

    #endregion

    #region class methods
    /// <summary>
    /// Return a list of all the categorys
    /// </summary>
    /// <returns></returns>
    public static List<Category> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToCategoryList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified category
    /// </summary>
    /// <param name="id">Cateogory id</param>
    /// <returns></returns>
    public static Category Get(string id)
    {
        Category br = new Category();
        bool found = false;

        foreach (Category b in Get())
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
            throw new RecordNotFoundException("Category", id);

    }

    /// <summary>
    /// Add new category
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool Add(Category b)
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

