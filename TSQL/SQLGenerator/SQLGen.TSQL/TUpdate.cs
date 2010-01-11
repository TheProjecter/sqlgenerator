using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TUpdate : IUpdate
    {
        StringBuilder sql;
        IFrom tfrom;
        IWhere twhere;

        public TUpdate()
        {
            this.sql = new StringBuilder();
            tfrom = new TFrom(sql);
            this.twhere = new TWhere(sql);
        }

        public TUpdate(StringBuilder sb)
        {
            this.sql = sb;
            tfrom = new TFrom(sql);
            this.twhere = new TWhere(sql);
        }

        public override string ToString()
        {
            return this.sql.ToString();
        }

        #region IUpdate Members

        public IUpdate Update(string tableName)
        {
            this.sql.AppendFormat(" \r\nUPDATE {0}",tableName);
            return this;
        }

        public IFrom AS(string alias)
        {
            this.sql.AppendFormat(" AS {0}", alias);
            return this.tfrom;
        }

        public IUpdate Set(string expression, string value)
        {
            this.sql.AppendFormat(" \r\nSET {0} = {1}",expression,value);
            return this;
        }

        public IUpdate Set(params string[] setexpressions)
        {
            if (setexpressions.Length >= 2)
            {
                bool addcomma = false;
                this.sql.AppendFormat(" \r\nSET");
                for (int i = 0; i < setexpressions.Length; i += 2)
                {
                    if (addcomma)
                    {
                        this.sql.AppendFormat(",");
                    }
                    else
                        addcomma = true;
                    this.sql.AppendFormat(" {0} = {1}",setexpressions[i],setexpressions[i+1]);
                }
            }
            else
            {
                throw new Exception(string.Format("Set expression is invalid \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public IWhere Where()
        {
            this.sql.AppendFormat(" \r\nWHERE");
            return this.twhere;
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

        public IUpdate And(string expression, string value)
        {
            this.sql.AppendFormat(",{0} = {1}", expression, value);
            return this;
        }

        #endregion
    }
}
