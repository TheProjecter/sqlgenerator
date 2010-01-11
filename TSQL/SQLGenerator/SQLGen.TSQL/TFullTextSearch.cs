using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TFullTextSearch : IFullTextSearch
    {

        #region IFullTextSearch Members

        public string Contians(string searchcondition, params string[] columnlist)
        {
            return string.Format(" CONTAINS({0},'{1}')",Utility.GetListAsString<string>(columnlist.ToList(),","),searchcondition.Trim('\''));
        }

        public string Contians(string searchcondition, string language, params string[] columnlist)
        {
            return string.Format(" CONTAINS({0},'{1}',LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.Trim('\''),language);
        }

        public string Contains(IFullTextSearchCondition searchcondition, params string[] columnlist)
        {
            return string.Format(" CONTAINS({0},{1})", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.ToString());
        }

        public string Contains(IFullTextSearchCondition searchcondition, string language, params string[] columnlist)
        {
            return string.Format(" CONTAINS({0},{1},LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.ToString(), language);
        }

        public string ContainsTable(string tableName, string searchcondition, params string[] columnList)
        {
            return string.Format(" CONTAINSTABLE({0},{1},'{2}')",tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.Trim('\''));
        }

        public string ContainsTable(string tableName, string searchcondition, string language, int top_n_byrank, params string[] columnList)
        {
            return string.Format(" CONTAINSTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.Trim('\''),language,top_n_byrank);
        }

        public string ContainsTable(string tableName, IFullTextSearchCondition searchcondition, params string[] columnList)
        {
            return string.Format(" CONTAINSTABLE({0},{1},{2})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.ToString());
        }

        public string ContainsTable(string tableName, IFullTextSearchCondition searchcondition, string language, int top_n_byrank, params string[] columnList)
        {
            return string.Format(" CONTAINSTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.ToString(), language, top_n_byrank);
        }

        public string FreeText(string searchterm, params string[] columnlist)
        {
            return string.Format(" FREETEXT({0},'{1}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.Trim('\''));
        }

        public string FreeText(string searchterm, string language, params string[] columnlist)
        {
            return string.Format(" FREETEXT({0},{1},LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.ToString(), language);
        }

        public string FreeTextTable(string tableName, string searchterm, params string[] columnlist)
        {
            return string.Format(" FREETEXTTABLE({0},{1},'{2}')", tableName, Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.Trim('\''));
        }

        public string FreeTextTable(string tableName, string searchterm, string language, int top_n_by_rank, params string[] columnlist)
        {
            return string.Format(" FREETEXTTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.Trim('\''), language, top_n_by_rank);
        }

        #endregion
    }
}
