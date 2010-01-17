using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;
using System.IO;

namespace SQLGen.TSQL
{
    public class TInsert : IInsert
    {
        StringBuilder sql;
        ISelect tselect;
        public TInsert()
        {

        }

        public TInsert(StringBuilder sb,ISelect ts)
        {
            this.sql = sb;
            this.tselect = ts;
        }
        #region IInsert Members

        public IInsert InsertInto(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" \r\nINSERT INTO {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" \r\nINSERT INTO");
                throw new Exception(string.Format("INSERT INTO table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IInsert InsertInto(string tableName, string columns)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" \r\nINSERT INTO {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" \r\nINSERT INTO");
                throw new Exception(string.Format("INSERT INTO table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            if (!string.IsNullOrEmpty(columns))
            {
                this.sql.AppendFormat(" ({0})", columns);
            }
            else
            {
                this.sql.AppendFormat(" ()");
                throw new Exception(string.Format("INSERT INTO columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IInsert InsertInto(string tableName, List<string> columns)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.sql.AppendFormat(" \r\nINSERT INTO {0}", tableName);
            }
            else
            {
                this.sql.AppendFormat(" \r\nINSERT INTO");
                throw new Exception(string.Format("INSERT INTO table name cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            string colstring = Utility.GetListAsString<string>(columns, ",");
            if (!string.IsNullOrEmpty(colstring))
            {
                this.sql.AppendFormat(" ({0})", colstring);
            }
            else
            {
                this.sql.AppendFormat(" ()");
                throw new Exception(string.Format("INSERT INTO columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public void Values(string values)
        {
            if (!string.IsNullOrEmpty(values))
            {
                this.sql.AppendFormat(" \r\nVALUES({0})", values);
            }
            else
            {
                this.sql.AppendFormat(" \r\nVALUES()");
                throw new Exception(string.Format("INSERT INTO values cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
        }

        public void Values(List<string> values)
        {
            string valstring = Utility.GetListAsString<string>(values, ",");
            if (!string.IsNullOrEmpty(valstring))
            {
                this.sql.AppendFormat(" \r\nVALUES({0})", valstring);
            }
            else
            {
                this.sql.AppendFormat(" \r\nVALUES()");
                throw new Exception(string.Format("INSERT INTO values cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
        }

        public ISelect SubQuery
        {
            get { return this.tselect; }
        }


        public List<string> Parse()
        {
            TSql100Parser parser = new TSql100Parser(false);
            IScriptFragment fragment;
            IList<ParseError> errors;
            fragment = parser.Parse(new StringReader(this.sql.ToString()), out errors);
            if (errors != null && errors.Count > 0)
            {
                List<string> errorList = new List<string>();
                foreach (var error in errors)
                {
                    errorList.Add(error.Message);
                }
                return errorList;
            }
            return null;
        }
        #endregion
    }
}
