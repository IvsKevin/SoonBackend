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
    public static Usuario ToUser(DataRow r)
    {
        Usuario b = new Usuario();
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
    public static List<Usuario> ToUserList(DataTable table)
    {
        List<Usuario> list = new List<Usuario>();
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

    #region Driver Data
    /// <summary>
    /// Maps a data row to a Driver Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Driver ToDriver(DataRow r)
    {
        Driver b = new Driver();
        b.Code = (int)r["driver_code"];
        b.Name = (string)r["driver_name"];
        b.Lastname = (string)r["driver_lastname"];
        b.Lastname2 = (string)r["driver_lastname2"];
        b.Phone = (string)r["driver_phone"];
        b.Bus = (int)r["driver_bus"];
        b.User = (int)r["driver_user"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Driver List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Driver> ToDriverList(DataTable table)
    {
        List<Driver> list = new List<Driver>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToDriver(dr));
        }
        return list;
    }
    #endregion

    #region Civil Data
    /// <summary>
    /// Maps a data row to a Civil Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Civil ToCivil(DataRow r)
    {
        Civil b = new Civil();
        b.Code = (int)r["civil_code"];
        b.Name = (string)r["civil_name"];
        b.Lastname = (string)r["civil_lastname"];
        b.Lastname2 = (string)r["civil_lastname2"];
        b.Phone = (string)r["civil_phone"];
        b.Birthday = (DateOnly)r["civil_birth"];
        b.User = (int)r["civil_user"];
        b.Card = (int)r["civil_card"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Civil List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Civil> ToCivilList(DataTable table)
    {
        List<Civil> list = new List<Civil>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToCivil(dr));
        }
        return list;
    }
    #endregion

    #region Transactions Data
    /// <summary>
    /// Maps a data row to a Transaction Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Transaction ToTransaction(DataRow r)
    {
        Transaction b = new Transaction();
        b.Code = (int)r["trans_code"];
        b.Type = (string)r["trans_type"];
        b.Date = (DateTime)r["trans_date"];
        b.Amount = (decimal)r["trans_amount"];
        b.Card = (int)r["trans_card"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Transaction List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Transaction> ToTransactionList(DataTable table)
    {
        List<Transaction> list = new List<Transaction>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToTransaction(dr));
        }
        return list;
    }
    #endregion

    #region ArrivalInfo Data
    /// <summary>
    /// Maps a data row to a ArrivalInfo Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static ArrivalInfo ToArrivalInfo(DataRow r)
    {
        ArrivalInfo b = new ArrivalInfo();
        b.Station = (int)r["arrival_station_code"];
        b.Bus = (int)r["arrival_bus_code"];
        b.DepartureTime = (DateTime)r["departureTime"];
        b.ArrivalTime = (DateTime)r["arrivalTime"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a ArrivalInfo List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<ArrivalInfo> ToArrivalInfoList(DataTable table)
    {
        List<ArrivalInfo> list = new List<ArrivalInfo>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToArrivalInfo(dr));
        }
        return list;
    }
    #endregion

    #region BusesDistribution Data
    /// <summary>
    /// Maps a data row to a BusesDistribution Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static BusesDistribution ToBusesDistribution(DataRow r)
    {
        BusesDistribution b = new BusesDistribution();
        b.Routes = (int)r["distribution_route_code"];
        b.Bus = (int)r["distribution_bus_code"];
        b.Day = (DateOnly)r["distribution_day"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a BusesDistribution List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<BusesDistribution> ToBusesDistributionList(DataTable table)
    {
        List<BusesDistribution> list = new List<BusesDistribution>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToBusesDistribution(dr));
        }
        return list;
    }
    #endregion

    #region RouteStation
    /// <summary>
    /// Maps a data row to a RouteStation Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static RouteStation ToRouteStation(DataRow r)
    {
        RouteStation b = new RouteStation();
        b.Route = (int)r["route_code"];
        b.Station = (int)r["station_code"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a RouteStation List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<RouteStation> ToRouteStationList(DataTable table)
    {
        List<RouteStation> list = new List<RouteStation>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToRouteStation(dr));
        }
        return list;
    }
    #endregion

    #region Calendar Data
    /// <summary>
    /// Maps a data row to a Calendar Object
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Calendar ToCalendar(DataRow r)
    {
        Calendar b = new Calendar();
        b.Driver = (int)r["calendar_driver_code"];
        b.Bus = (int)r["calendar_bus_code"];
        b.Day = (DateOnly)r["calendar_day"];
        return b;
    }

    /// <summary>
    /// Maps a data table to a Calendar List
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static List<Calendar> ToCalendarList(DataTable table)
    {
        List<Calendar> list = new List<Calendar>();
        foreach (DataRow dr in table.Rows)
        {
            list.Add(ToCalendar(dr));
        }
        return list;
    }
    #endregion
}

