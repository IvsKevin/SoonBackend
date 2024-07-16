using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Product : Catalog
{
    #region statements
    private static string select = @"SELECT id AS product_id, description AS product_description,
    brand AS product_brand, category AS product_category, price AS product_price
    FROM products ORDER BY product_description";
    private static string selecOne = @"SELECT id AS product_id, description AS product_description,
    brand AS product_brand, category AS product_category, price AS product_price
    FROM products WHERE id = @ID";
    private static string add = @"INSERT INTO products (id, description, brand, category, price) 
    VALUES (@ID, @DESC, @BRAND, @CAT, @PRICE);";
    #endregion

    #region attributes 
        private Brand _brand;
        private Category _category;
        private float _price;
    #endregion

    #region properties
        public Brand Brand { get => _brand; set => _brand = value; }
        public Category Category { get => _category; set => _category = value; }
        public float Price { get => _price; set => _price = value; }
    #endregion

    #region constructors
    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Product()
    {
        _id = "";
        _description = "";
        _brand = new Brand();
        _category = new Category();
        _price = 1.0f;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="description">Product description</param>
    /// <param name="brand">Brand</param>
    /// <param name="category">Category</param>
    /// <param name="price">Product price</param>
    public Product(string id, string description, Brand brand, Category category, float price)
        {
            _id = id;
            _description = description;
            _brand = brand;
            _category = category;
            _price = price;
        }
    #endregion

    #region instance methods
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
    /// Return a list of all the products
    /// </summary>
    /// <returns></returns>
    public static List<Product> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToProductList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified product
    /// </summary>
    /// <param name="id">Cateogory id</param>
    /// <returns></returns>
    public static Product Get(string id)
    {
        Product br = new Product();
        bool found = false;

        foreach (Product b in Get())
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
            throw new RecordNotFoundException("Product", id);

    }

    /// <summary>
    /// Add new Product
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool Add(Product b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@ID", b.Id);
        command.Parameters.AddWithValue("@DESC", b.Description);
        command.Parameters.AddWithValue("@BRAND", b.Brand);
        command.Parameters.AddWithValue("@CAT", b.Category);
        command.Parameters.AddWithValue("@PRICE", b.Price);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }

    /// <summary>
    /// Represents the objects as a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _id + " : " + _description + " > " + _brand + " > " + _category + " > " + _price;
    }
    #endregion
}

