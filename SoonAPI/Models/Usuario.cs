using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Usuario
{
    #region statements
    private const string select = "SELECT code AS user_code, email AS user_email, password AS user_password, UserType AS user_type FROM [User] ORDER BY user_code";
    private const string validateCredentials = @"SELECT 
    code AS user_code, email AS user_email, password AS user_password, UserType AS user_type 
    FROM [User] WHERE email = @MAIL AND password = @PASS"; 
    private const string add = "INSERT INTO [User] (email, password, UserType) VALUES (@MAIL, @PASS, @TYPE);";
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
    public Usuario()
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
    public Usuario(string email, string password, int user_type)
    {
        _email = email;
        _password = password;
        _user_tyoe = user_type;
    }

    #endregion

    #region instance methods

    /// <summary>
    /// Validates user credentials
    /// </summary>
    /// <param name="email">User email</param>
    /// <param name="password">User password</param>
    /// <returns>Usuario if credentials are valid, otherwise null</returns>
    public static Usuario? ValidateCredentials(string email, string password)
    {
        // Command
        SqlCommand command = new SqlCommand(validateCredentials);
        // Parameters
        command.Parameters.AddWithValue("@MAIL", email);
        command.Parameters.AddWithValue("@PASS", password);
        // Execute query
        DataTable result = SqlServerConnection.ExecuteQuery(command);

        // Check if any row is returned
        if (result.Rows.Count > 0)
        {
            DataRow row = result.Rows[0];
            return new Usuario
            {
                Code = (int)row["user_code"],
                Email = (string)row["user_email"],
                Password = (string)row["user_password"],
                UserType = (int)row["user_type"]
            };
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region class methods
    /// <summary>
    /// Return a list of all the users
    /// </summary>
    /// <returns></returns>
    public static List<Usuario> Get()
    {
        // Command
        SqlCommand command = new SqlCommand(select);
        // Execute query
        return Mapper.ToUserList(SqlServerConnection.ExecuteQuery(command));
    }

    /// <summary>
    /// Returns the specified Usuario
    /// </summary>
    /// <param name="id">Usuario id</param>
    /// <returns></returns>
    public static Usuario Get(string id)
    {
        // Convertir id a entero
        if (!int.TryParse(id, out int intId))
        {
            throw new ArgumentException2("El id proporcionado no es un número válido.");
        }

        Usuario? br = null;
        foreach (Usuario b in Get())
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
            throw new RecordNotFoundException("Usuario", id);
        }
    }


    public static bool Add(Usuario b)
    {
        // Command
        SqlCommand command = new SqlCommand(add);
        // Parameters
        command.Parameters.AddWithValue("@MAIL", b.Email);
        command.Parameters.AddWithValue("@PASS", b.Password);
        command.Parameters.AddWithValue("@TYPE", b.UserType);
        // Execute command
        return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Update(Usuario u)
    {
        const string updateSql = @"UPDATE [User] SET email = @MAIL, password = @PASS, UserType = @TYPE WHERE code = @CODE;";
        SqlCommand command = new SqlCommand(updateSql);
        command.Parameters.AddWithValue("@MAIL", u.Email);
        command.Parameters.AddWithValue("@PASS", u.Password);
        command.Parameters.AddWithValue("@TYPE", u.UserType);
        command.Parameters.AddWithValue("@CODE", u.Code);

        return SqlServerConnection.ExecuteNonQuery(command);
    }

    public static bool Delete(string id)
    {
        const string deleteSql = "DELETE FROM [User] WHERE code = @CODE;";

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

