using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Catalog
{
    #region attributes

    protected string _id;
    protected string _description;

    #endregion

    #region properties

    public string Id { get => _id; set => _id = value; }
    public string Description { get => _description; set => _description = value; }

    #endregion

    #region instance methods
    /// <summary>
    /// Represents the objects as a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _id + " : " + _description;
    }

    #endregion
}

