using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IFullTextSearch
    {       
        string Contians(string searchcondition,params string[] columnlist);
        string Contians(string searchcondition, string language, params string[] columnlist);
        string Contains(IFullTextSearchCondition searchcondition, params string[] columnlist);
        string Contains(IFullTextSearchCondition searchcondition, string language, params string[] columnlist);
        string ContainsTable(string tableName, string searchcondition, params string[] columnList);
        string ContainsTable(string tableName, string searchcondition, string language, int top_n_byrank, params string[] columnList);
        string ContainsTable(string tableName, IFullTextSearchCondition searchcondition, params string[] columnList);
        string ContainsTable(string tableName, IFullTextSearchCondition searchcondition, string language, int top_n_byrank, params string[] columnList);
        string FreeText(string searchterm, params string[] columnlist);
        string FreeText(string searchterm, string language, params string[] columnlist);
        string FreeTextTable(string tableName, string searchterm, params string[] columnlist);
        string FreeTextTable(string tableName, string searchterm, string language, int top_n_by_rank, params string[] columnlist);
    }
}
