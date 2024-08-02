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

public class Transaction
{
    #region statements
    private const string select = @"
    SELECT code AS trans_code, transactionType AS trans_type, transactionDate AS trans_date, amount AS trans_amount,
    card AS trans_card
    FROM Transactions 
    ORDER BY trans_code";
    //private static string selecOne = "SELECT id AS brand_id, description AS brand_description FROM brands WHERE id = @ID ";
    private const string add = @"INSERT INTO Transactions 
    (transactionType, transactionDate, amount, card) 
    VALUES  (@TYPE, @DATE, @AMOUNT, @CARD);";
    #endregion

    #region attributes 
    private int _code;
    private string _type;
    private DateTime _date;
    private decimal _amount;
    private int _card;
    #endregion

    #region properties
    public int Code { get => _code; set => _code = value; }
    public string Type { get => _type; set => _type = value; }
    public DateTime Date { get => _date; set => _date = value; }
    public decimal Amount { get => _amount; set => _amount = value; }
    public int Card { get => _card; set => _card = value; }
    #endregion

    #region constructors

    /// <summary>
    /// Creates an empty object
    /// </summary>
    public Transaction()
    {
        _code = 0;
        _type = "";
        _date = DateTime.Now;
        _amount = 0;
        _card = 0;
    }

    /// <summary>
    /// Creates an object with values from the arguments
    /// </summary>
    /// <param name="id">Brand id</param>
    /// <param name="description">Brand description</param>
    public Transaction(string type, DateTime date, decimal amount, int card)
    {
        _type = type;
        _date = date;
        _amount = amount;
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
    /// Return a list of all the Transactions
    /// </summary>
    /// <returns></returns>
    public static List<Transaction> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToTransactionList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified Transaction
    /// </summary>
    /// <param name="id">Transaction id</param>
    /// <returns></returns>
    public static Transaction Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        Transaction? br = null;
        foreach (Transaction b in Get())
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
            throw new RecordNotFoundException("Transaction", id);
        }
    }

    public static bool Add(Transaction b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@TYPE", b.Type);
        command.Parameters.AddWithValue("@DATE", b.Date);
        command.Parameters.AddWithValue("@AMOUNT", b.Amount);
        command.Parameters.AddWithValue("@CARD", b.Card);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }
    #endregion
}

