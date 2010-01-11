using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IInsert
    {
        IInsert InsertInto(string tableName);
        IInsert InsertInto(string tableName,string columns);
        IInsert InsertInto(string tableName, List<string> columns);
        void Values(string values);
        void Values(List<string> values);
        ISelect SubQuery
        {
            get;
        }

    }
}
