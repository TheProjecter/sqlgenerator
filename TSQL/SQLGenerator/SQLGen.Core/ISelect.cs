using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface ISelect : ICommon
    {
        IFrom Select(string columns);
        IFrom Select(List<string> columns, params IAggregate[] aggregates);
        IFrom Select(List<string> columns);
        IFrom Select(params string[] columns);
        IFrom Select(int top, params string[] columns);
        IFrom SelectDistinct(string columns);
        IFrom SelectDistinct(List<string> columns, params IAggregate[] aggregates);
        IFrom SelectDistinct(List<string> columns);
        IFrom SelectDistinct(params string[] columns);
        IFrom SelectDistinct(int top, params string[] columns);
        IWhere Where();
        IWhere Where(string condition);   
    }
}
