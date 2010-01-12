using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TFrom : IFrom
    {
        StringBuilder sql;
        IWhere twhere;
        TCondition tcondition;
        public TFrom()
        {
            sql = new StringBuilder();
            twhere = new TWhere(sql);
            tcondition = new TCondition(sql);
        }
        public TFrom(StringBuilder sb)
        {
            this.sql = sb;
            this.twhere = new TWhere(sb);
            tcondition = new TCondition(sb);
        }

        public override string ToString()
        {
            return this.sql.ToString();
        }

        #region IFrom Members

        public IFrom InnerJoin(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" INNER JOIN {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" INNER JOIN");
                throw new Exception(string.Format("INNER JOIN table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom CrossJoin(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" CROSS JOIN {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" CROSS JOIN");
                throw new Exception(string.Format("CROSS JOIN table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom LeftOuterJoin(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" LEFT OUTER JOIN {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" LEFT OUTER JOIN");
                throw new Exception(string.Format("LEFT OUTER JOIN table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom RightOuterJoin(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" RIGHT OUTER JOIN {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" RIGHT OUTER JOIN ");
                throw new Exception(string.Format("RIGHT OUTER JOIN table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom FullOuterJoin(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" FULL OUTER JOIN {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" FULL OUTER JOIN ");
                throw new Exception(string.Format("FULL OUTER JOIN table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom From(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" \r\nFROM {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" \r\nFROM ");
                throw new Exception(string.Format("Table name cannot be null or empty \r\n'{0}'",this.sql.ToString()));
            }
            return this;
        }

        public IWhere On(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" \r\nON {0}", condition);
            }
            else
            {
                sql.AppendFormat(" \r\nON");
                throw new Exception(string.Format("ON condition cannot be null or empty \r\n'{0}'",this.sql.ToString()));
            }
            return this.twhere;
        }

        public IFrom As(string alias)
        {
            if (!string.IsNullOrEmpty(alias))
            {
                this.sql.AppendFormat(" AS [{0}]", alias.Trim(']', '['));
            }
            else
            {
                this.sql.AppendFormat(" AS []");
                throw new Exception(string.Format("Alias cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom From(ISelect derivedTable)
        {
            this.sql.AppendFormat(" FROM ({0})",derivedTable.ToString());
            return this;
        }

        public IFrom GroupBy(string columns)
        {
            if (!string.IsNullOrEmpty(columns))
            {
                this.sql.AppendFormat(" \r\nGROUP BY {0}", columns);
            }
            else
            {
                this.sql.AppendFormat(" \r\nGROUP BY");
                throw new Exception(string.Format("GROUP BY columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom GroupBy(params string[] columns)
        {
            string colstring = Utility.GetListAsString<string>(columns.ToList(), ",");
            if (!string.IsNullOrEmpty(colstring))
            {
                this.sql.AppendFormat(" \r\nGROUP BY {0}", colstring);
            }
            else
            {
                this.sql.AppendFormat(" \r\nGROUP BY");
                throw new Exception(string.Format("GROUP BY columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IFrom OrderBy(string columns)
        {
            if (!string.IsNullOrEmpty(columns))
            {
                this.sql.AppendFormat(" \r\nORDER BY {0}", columns);
            }
            else
            {
                this.sql.AppendFormat(" \r\nORDER BY");
                throw new Exception(string.Format("ORDER BY columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IWhere Having(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" \r\nHAVING {0}", condition);
            }
            else
            {
                this.sql.AppendFormat(" \r\nHAVING ");
                throw new Exception(string.Format("HAVING condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.twhere;
        }

        public IFrom Into(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" \r\nINTO {0}", tableName);
            }
            else
            {
                sql.AppendFormat(" \r\nINTO");
                throw new Exception(string.Format("INTO table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IWhere Where(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" \r\nWHERE {0}", condition);
            }
            else
            {
                this.sql.AppendFormat(" \r\nWHERE");
                throw new Exception(string.Format("WHERE condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.twhere;
        }

        public IWhere WhereContains(string columnName, string value)
        {
            if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(value))
            {
                this.sql.AppendFormat(" \r\nWHERE CONTAINS(");
                throw new Exception(string.Format("CONTAINS column name or value cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            else
            {
                this.sql.AppendFormat(" \r\nWHERE CONTAINS({0},'{1}')", columnName, value);
            }
            return this.twhere;
        }        


        public void Close()
        {
            sql.Append(";");
        }

        public void Close(string endSimpol)
        {
            sql.AppendFormat("\r\n{0}",endSimpol);
        }

        #endregion

        #region IFrom Members


        ICondition IFrom.On(string condition)
        {
            this.sql.AppendFormat(" ON {0}", condition);
            return this.tcondition;
        }

        public IFrom On(ICondition condition)
        {
            this.sql.AppendFormat(" ON {0}",condition.ToString());
            return this;
        }

        public IFrom From()
        {
            this.sql.Append(" \r\nFROM");
            return this;
        }
       

        public IWhere Where()
        {
            this.sql.Append(" WHERE");
            return this.twhere;
        }


        public IFrom ContainsTable(string tableName, string searchcondition, params string[] columnList)
        {
            this.sql.AppendFormat(" CONTAINSTABLE({0},{1},'{2}')", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.Trim('\''));
            return this;
        }

        public IFrom ContainsTable(string tableName, string searchcondition, string language, int top_n_byrank, params string[] columnList)
        {
            this.sql.AppendFormat(" CONTAINSTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.Trim('\''), language, top_n_byrank);
            return this;
        }

        public IFrom ContainsTable(string tableName, IFullTextSearchCondition searchcondition, params string[] columnList)
        {
            this.sql.AppendFormat(" CONTAINSTABLE({0},{1},{2})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.ToString());
            return this;
        }

        public IFrom ContainsTable(string tableName, IFullTextSearchCondition searchcondition, string language, int top_n_byrank, params string[] columnList)
        {
            this.sql.AppendFormat(" CONTAINSTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnList.ToList(), ","), searchcondition.ToString(), language, top_n_byrank);
            return this;
        }

        public IFrom FreeTextTable(string tableName, string searchterm, params string[] columnlist)
        {
            this.sql.AppendFormat(" FREETEXTTABLE({0},{1},'{2}')", tableName, Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.Trim('\''));
            return this;
        }

        public IFrom FreeTextTable(string tableName, string searchterm, string language, int top_n_by_rank, params string[] columnlist)
        {
            this.sql.AppendFormat(" FREETEXTTABLE({0},{1},'{2}', LANGUAGE N'{3}',{4})", tableName, Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.Trim('\''), language, top_n_by_rank);
            return this;
        }

        #endregion
    }
}
