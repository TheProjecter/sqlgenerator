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
