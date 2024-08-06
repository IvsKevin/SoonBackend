using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Card
{
    #region statements
    private const string select = @"SELECT code AS card_code, 
    balance AS card_balance FROM Card ORDER BY card_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = "INSERT INTO Card (balance) VALUES (@BALANCE);";
    #endregion

    #region attributes 
    private int _code;
    private decimal _balance;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public decimal Balance { get => _balance; set => _balance = value; }
    #endregion

    #region constructors
    public Card()
    {
        _code = 0;
        _balance = 0;
    }

    public Card(decimal balance)
    {
        _balance = balance;
    }

    #endregion

    #region instance methods

    #endregion

    #region class methods
    /// <summary>
    /// Return a list of all the Cards
    /// </summary>
    /// <returns></returns>
    public static List<Card> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToCardList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified Card
    /// </summary>
    /// <param name="id">UserType id</param>
    /// <returns></returns>
    public static Card Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        Card? br = null;
        foreach (Card b in Get())
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
            throw new RecordNotFoundException("Card", id);
        }
    }


    public static bool Add(Card b)
    {
            // Command
            SqlCommand command = new SqlCommand(add);
            // Parameters
            command.Parameters.AddWithValue("@BALANCE", b.Balance);
            // Execute command
            return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Update(Card b)
    {
        const string updateSql = @"UPDATE Card SET balance = @BALANCE WHERE code = @CODE;";
        SqlCommand command = new SqlCommand(updateSql);
        command.Parameters.AddWithValue("@BALANCE", b.Balance);
        command.Parameters.AddWithValue("@CODE", b.Code);

        return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Delete(string id)
    {
        const string deleteSql = "DELETE FROM Card WHERE code = @CODE;";

        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        SqlCommand command = new SqlCommand(deleteSql);
        command.Parameters.AddWithValue("@CODE", intId);

        return SqlServerConnection.ExecuteNonQuery(command);
    }

    #endregion
}

