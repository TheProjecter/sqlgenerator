using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TAggregate : IAggregate
    {
        private StringBuilder sql;

        public override string ToString()
        {
            return this.sql.ToString();
        }

        public TAggregate()
        {
            sql = new StringBuilder();
        }

        public TAggregate(StringBuilder sb)
        {
            this.sql = sb;
        }
        #region IAggregate Members

        public IAggregate Max(string column)
        {
            sql.AppendFormat(" MAX({0})", column);
            return this;
        }

        public IAggregate Min(string column)
        {
            sql.AppendFormat(" MIN({0})", column);
            return this;
        }

        public IAggregate Avg(string column)
        {
            sql.AppendFormat(" AVG({0})", column);
            return this;
        }

        public IAggregate Count(string column)
        {
            sql.AppendFormat(" COUNT({0})", column);
            return this;
        }

        public IAggregate Sum(string column)
        {
            sql.AppendFormat(" SUM({0})", column);
            return this;
        }

        public IAggregate As(string alias)
        {
            sql.AppendFormat(" AS [{0}]", alias.Trim(']', '['));
            return this;
        }

        #endregion
    }
}
