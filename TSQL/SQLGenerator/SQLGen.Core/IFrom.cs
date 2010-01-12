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
        IFrom ContainsTable(string tableName, string searchcondition, params string[] columnList);
        IFrom ContainsTable(string tableName, string searchcondition, string language, int top_n_byrank, params string[] columnList);
        IFrom ContainsTable(string tableName, IFullTextSearchCondition searchcondition, params string[] columnList);
        IFrom ContainsTable(string tableName, IFullTextSearchCondition searchcondition, string language, int top_n_byrank, params string[] columnList);
        IFrom FreeTextTable(string tableName, string searchterm, params string[] columnlist);
        IFrom FreeTextTable(string tableName, string searchterm, string language, int top_n_by_rank, params string[] columnlist);
        IWhere Where();
        IWhere Where(string condition);
    }
}
