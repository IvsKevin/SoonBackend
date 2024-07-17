using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    internal class Mapper
    {

    #region User Data
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
        b.UserType = (int)r["user_type"];
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
    #endregion

    #region Station Data
    // Station data

    /// <summary>
    /// Maps a data row to a Station Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Station ToStation(DataRow r)
    {
        Station b = new Station();
        b.Code = (int)r["station_code"];
        b.Name = (string)r["station_name"];
        b.Location = (string)r["station_location"];
        b.Status = (bool)r["station_status"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Station List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Station> ToStationList(DataTable table)
    {
        List<Station> list = new List<Station>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToStation(dr));
        }
        return list;
    }    
    #endregion

    #region Routes Data
    // Routes data

    /// <summary>
    /// Maps a data row to a Routes Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Routes ToRoutes(DataRow r)
    {
        Routes b = new Routes();
        b.Code = (int)r["routes_code"];
        b.Name = (string)r["routes_name"];
        b.Status = (bool)r["routes_status"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Routes List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Routes> ToRoutesList(DataTable table)
    {
        List<Routes> list = new List<Routes>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToRoutes(dr));
        }
        return list;
    }
    #endregion

    #region Bus Data
    // Bus data

    /// <summary>
    /// Maps a data row to a Bus Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Bus ToBus(DataRow r)
    {
        Bus b = new Bus();
        b.Code = (int)r["bus_code"];
        b.Plates = (string)r["bus_plates"];
        b.Capacity = (int)r["bus_capacity"];
        b.Status = (bool)r["bus_status"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Bus List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Bus> ToBusList(DataTable table)
    {
        List<Bus> list = new List<Bus>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToBus(dr));
        }
        return list;
    }
    #endregion

    #region UserType Data
    // Bus data

    /// <summary>
    /// Maps a data row to a UserType Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static UserType ToUserType(DataRow r)
    {
        UserType b = new UserType();
        b.Code = (int)r["user_type_code"];
        b.Description = (string)r["user_type_description"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a UserType List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<UserType> ToUserTypeList(DataTable table)
    {
        List<UserType> list = new List<UserType>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToUserType(dr));
        }
        return list;
    }
    #endregion
}

