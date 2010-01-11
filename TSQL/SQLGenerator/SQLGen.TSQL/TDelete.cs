using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TDelete : IDelete
    {
        StringBuilder sql;
        IFrom tfrom;
        public TDelete()
        {
            sql = new StringBuilder();
            tfrom = new TFrom(sql);
        }

        public TDelete(StringBuilder sb)
        {
            this.sql = sb;
            tfrom = new TFrom(sql);
        }

        public override string ToString()
        {
            return this.sql.ToString();
        }

        #region IDelete Members

        public IFrom DeleteFrom(string tableName)
        {
            this.sql.AppendFormat(" \r\nDELETE FROM {0}",tableName);
            return this.tfrom;
        }

        #endregion
    }
}
