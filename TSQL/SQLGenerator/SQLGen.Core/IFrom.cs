using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IFrom
    {
        IFrom InnerJoin(string tableName);
        IFrom CrossJoin(string tableName);
        IFrom LeftOuterJoin(string tableName);
        IFrom RightOuterJoin(string tableName);
        IFrom FullOuterJoin(string tableName);
        IFrom Into(string tableName);
        IFrom From(string tableName);
        ICondition On(string condition);
        IFrom On(ICondition condition);
        IFrom As(string alias);
        IFrom From();
        IFrom From(ISelect derivedTable);
        IFrom ContainsTable(IFullTextSearch ftsearch);
        IFrom ContainsTable(string ftsearch);
        IFrom FreeTextTable(IFullTextSearch ftsearch);
        IFrom FreeTextTable(string ftsearch);
        IWhere Where();
        IWhere Where(string condition);
    }
}
