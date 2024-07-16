using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    internal class Mapper
    {
    // User data
  
    /// <summary>
    /// Maps a data row to a User Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static User ToUser(DataRow r)
    {
        User b = new User();
        b.Code = (int)r["user_code"];
        b.Email = (string)r["user_email"];
        b.Password = (string)r["user_password"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a User List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<User> ToUserList(DataTable table)
    {
        List<User> list = new List<User>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToUser(dr));
        }
        return list;
    }


    // Brand Data
    /// <summary>
    /// Maps a data row to a Brand Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Brand ToBrand(DataRow r)
        {
            Brand b = new Brand();
            b.Id = (string)r["brand_id"];
            b.Description = (string)r["brand_description"];
            return b;
        }

    /// <summary>
    /// Maps a data table to a Brand List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Brand> ToBrandList(DataTable table)
    {
        List<Brand> list = new List<Brand>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToBrand(dr));
        }
        return list;
    }


    // Category Data
    /// <summary>
    /// Maps a data row to a Category Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Category ToCategory(DataRow r)
    {
        Category b = new Category();
        b.Id = (string)r["category_id"];
        b.Description = (string)r["category_description"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Category List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Category> ToCategoryList(DataTable table)
    {
        List<Category> list = new List<Category>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToCategory(dr));
        }
        return list;
    }


    // Products Data
    /// <summary>
    /// Maps a data row to a Products Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Product ToProduct(DataRow r)
    {
        Product b = new Product();
        b.Id = (string)r["product_id"];
        b.Description = (string)r["product_description"];
        b.Brand = new Brand { Id = (string)r["product_brand"] };
        b.Category = new Category { Id = (string)r["product_category"] };
        b.Price = Convert.ToSingle(r["product_price"]);

        return b;
    }

    /// <summary>
    /// Maps a data table to a Product List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Product> ToProductList(DataTable table)
    {
        List<Product> list = new List<Product>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToProduct(dr));
        }
        return list;
    }

}

