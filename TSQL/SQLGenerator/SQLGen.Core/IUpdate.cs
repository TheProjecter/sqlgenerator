using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IUpdate
    {
        IUpdate Update(string tableName);
        IFrom AS(string alias);
        IUpdate Set(string expression, string value);
        IUpdate Set(params string[] setexpressions);
        IUpdate And(string expression, string value);
        IWhere Where();
        IWhere Where(string condition);
    }
}
