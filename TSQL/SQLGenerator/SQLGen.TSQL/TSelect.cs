using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;
using System.Xml;
using System.IO;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;

namespace SQLGen.TSQL
{
    public class TSelect : ISelect
    {
        StringBuilder sql;
        XmlDocument doc;
        IFrom tfrom;
        IWhere twhere;
        public TSelect()
        {
            sql = new StringBuilder();
            twhere = new TWhere(sql);
            tfrom = new TFrom(sql);
        }
        public TSelect(StringBuilder sb,IFrom tf,IWhere tw)
        {
            this.sql = sb;
            this.tfrom = tf;
            this.twhere = tw;
        }


        public override string ToString()
        {
            return this.sql.ToString();
        }
        #region ISelect Members

        public IFrom Select(string columns)
        {
            if (!string.IsNullOrEmpty(columns))
            {
                sql.AppendFormat(" \r\nSELECT {0}", columns);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom Select(List<string> columns, params IAggregate[] aggregates)
        {
            string colstring = Utility.GetListAsString<string>(columns,",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT {0}", colstring);
                colstring = Utility.GetListAsString<IAggregate>(aggregates.ToList(), ",");
                if (colstring != string.Empty)
                    this.sql.AppendFormat(",{0}", colstring);
            }
            else
            {
                colstring = Utility.GetListAsString<IAggregate>(aggregates.ToList(), ",");
                if (colstring != string.Empty)
                    this.sql.AppendFormat(" \r\nSELECT {0}", colstring);
                else
                {
                    sql.AppendFormat(" \r\nSELECT");
                    throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
                }
            }
            return this.tfrom;
        }

        public IFrom Select(List<string> columns)
        {
            string colstring = Utility.GetListAsString<string>(columns, ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT {0}", colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom Select(params string[] columns)
        {
            string colstring = Utility.GetListAsString<string>(columns.ToList(), ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT {0}", colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom Select(int top, params string[] columns)
        {
            string colstring = Utility.GetListAsString<string>(columns.ToList(), ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT TOP {0} {1}", top, colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }              
        
        public void Close()
        {
            sql.Append(";");
        }

        public void Close(string separator)
        {
            sql.Append("\r\n" + separator);
        }   
        #endregion

        #region ISelect Members


        public IFrom SelectDistinct(string columns)
        {
            if (!string.IsNullOrEmpty(columns))
            {
                sql.AppendFormat(" \r\nSELECT DISTINCT {0}", columns);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT DISTINCT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom SelectDistinct(List<string> columns, params IAggregate[] aggregates)
        {
            string colstring = Utility.GetListAsString<string>(columns, ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT DISTINCT {0}", colstring);
                colstring = Utility.GetListAsString<IAggregate>(aggregates.ToList(), ",");
                if (colstring != string.Empty)
                    this.sql.AppendFormat(",{0}", colstring);
            }
            else
            {
                colstring = Utility.GetListAsString<IAggregate>(aggregates.ToList(), ",");
                if (colstring != string.Empty)
                    this.sql.AppendFormat(" \r\nSELECT DISTINCT {0}", colstring);
                else
                {
                    sql.AppendFormat(" \r\nSELECT");
                    throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
                }
            }
            return this.tfrom;
        }

        public IFrom SelectDistinct(List<string> columns)
        {
            string colstring = Utility.GetListAsString<string>(columns, ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT DISTINCT {0}", colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT DISTINCT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom SelectDistinct(params string[] columns)
        {
            string colstring = Utility.GetListAsString<string>(columns.ToList(), ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT DISTINCT {0}", colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT DISTINCT");
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IFrom SelectDistinct(int top, params string[] columns)
        {
            string colstring = Utility.GetListAsString<string>(columns.ToList(), ",");
            if (colstring != string.Empty)
            {
                this.sql.AppendFormat(" \r\nSELECT DISTINCT TOP {0} {1}", top, colstring);
            }
            else
            {
                sql.AppendFormat(" \r\nSELECT DISTINCT TOP {0}",top);
                throw new Exception(string.Format("SELECT columns cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tfrom;
        }

        public IWhere Where()
        {
            this.sql.Append(" WHERE");
            return this.twhere;
        }

        public IWhere Where(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" WHERE {0}", condition);
            }
            else
            {
                this.sql.AppendFormat(" WHERE");
                throw new Exception(string.Format("WHERE condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.twhere;
        }

        #endregion

        #region ICommon Members

        public void LoadXml(string xml)
        {
            this.doc = new XmlDocument();
            this.doc.LoadXml(xml);
        }

        public void LoadXml(XmlDocument xdoc)
        {
            this.doc = xdoc;
        }

        public void LoadXmlFromFile(string filePath)
        {
            this.doc = new XmlDocument();
            this.doc.Load(filePath);
        }

        public void AppendSqlFromXml(string statementName, params string[] objs)
        {
            XmlNode sqlst = this.doc.SelectSingleNode(string.Format("//statement[@name=\"{0}\"]",statementName));
            if (sqlst != null && !string.IsNullOrEmpty(sqlst.InnerText))
                this.sql.AppendFormat(sqlst.InnerText, objs);
            else
            {
                throw new Exception(string.Format("Statement loaded from XML cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
        }

        public void AppendSqlFromXmlHeader(params string[] objs)
        {
            XmlNode sqlst = this.doc.SelectSingleNode("//header");
            if (sqlst != null && !string.IsNullOrEmpty(sqlst.InnerText))
            {
                this.sql.Insert(0,string.Format(sqlst.InnerText + " ", objs));
            }
            else
            {
                throw new Exception(string.Format("Statement loaded from XML header cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
        }

        public void AppendSqlFromXmlFooter(params string[] objs)
        {
            XmlNode sqlst = this.doc.SelectSingleNode("//footer");
            if (sqlst != null && !string.IsNullOrEmpty(sqlst.InnerText))
                this.sql.AppendFormat(sqlst.InnerText, objs);
            else
            {
                throw new Exception(string.Format("Statement loaded from XML footer cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
        }

        public void Append(string statement)
        {
            this.sql.AppendFormat(" {0}", statement);
        }

        public void SaveTo(string filePath)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.Write(this.sql.ToString());
                sw.Flush();
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
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
