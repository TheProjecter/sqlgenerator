using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;
using System.IO;
using System.Xml;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;

namespace SQLGen.TSQL
{
    public class SQL : ISQL
    {
        StringBuilder sql;
        ISelect tselect;
        IFrom tfrom;
        IWhere twhere;
        IInsert tinsert;
        IUpdate tupdate;
        IDelete tdelete;
        ICondition tcondition;
        XmlDocument doc;
        public SQL()
        {
            sql = new StringBuilder();
            twhere = new TWhere(this.sql);
            tfrom = new TFrom(this.sql);
            tselect = new TSelect(this.sql, this.tfrom,twhere);
            tinsert = new TInsert(this.sql, this.tselect);
            tcondition = new TCondition(sql);
            tdelete = new TDelete(sql);
            tupdate = new TUpdate(sql);
            
        }

        public override string ToString()
        {
            return this.sql.ToString();
        }

        public static SQL FromFile(string filePath)
        {
            SQL s = new SQL();
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Read);
                sr = new StreamReader(fs);
                s.Append(sr.ReadToEnd());
                return s;
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
            
        }

        #region ISQL Members

        public ISelect SelectStatement
        {
            get { return this.tselect; }
        }

        public IInsert InsertStatement
        {
            get
            {
                return this.tinsert;
            }
        }

        public string DeclareColumn(string varName, System.Data.SqlDbType type, int size)
        {
            return string.Format(" \r\n{0} {1}{2}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "");
        }

        public string DeclareColumn(string varName, System.Data.SqlDbType type, int size, bool allowNull)
        {
            return string.Format(" \r\n{0} {1}{2} {3}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "", (allowNull) ? "NULL" : "NOT NULL");
        }

        public string DeclareColumn(string varName, System.Data.SqlDbType type, int size, bool isPrimaryKey, bool isIdentity)
        {
            return string.Format(" \r\n{0} {1}{2} {3}{4}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "", (isIdentity) ? "IDENTITY" : "", (isPrimaryKey) ? " PRIMARY KEY" : "");
        }

        public string DeclareVariable(string varName, System.Data.SqlDbType type, int size)
        {
            return string.Format(" \r\nDECLARE {0} AS {1}{2}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "");
        }

        public string DeclareVariables(System.Data.SqlDbType type, int size, params string[] varNames)
        {
            return string.Format(" \r\nDECLARE {0} AS {1}{2}", Utility.GetListAsString<string>(varNames.ToList(), ","), type.ToString(), (size != 0) ? string.Format("({0})", size) : "");
        }

        public string SetVariable(string varName, string value)
        {
            return string.Format(" \r\nSET {0} = {1}", varName, value);
        }

        public string CreateTable(string tableName, params string[] columns)
        {
            return string.Format(" \r\nCREATE TABLE {0}({1})", tableName, Utility.GetListAsString<string>(columns.ToList(), ","));
        }

        public string ExecuteSP(string spName, params string[] paramValues)
        {
            return string.Format(" \r\nEXECUTE {0} {1}", spName, Utility.GetListAsString<string>(paramValues.ToList(), ","));
        }                

        public void Close()
        {
            sql.Append(";");
        }

        public void Close(string endSimpol)
        {
            sql.AppendFormat("\r\n{0}", endSimpol);
        }        

        public ICondition AppendIf(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" \r\nIF {0}", condition);
            }
            else
            {
                this.sql.AppendFormat(" \r\nIF");
                throw new Exception(string.Format("IF condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tcondition;
        }

        public ICondition AppendWhile(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" \r\nWHILE {0}", condition);
            }
            else
            {
                this.sql.AppendFormat(" \r\nWHILE");
                throw new Exception(string.Format("WHILE condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this.tcondition;
        }
        public ISQL As()
        {
            this.sql.AppendFormat(" \r\nAS");
            return this;
        }          
        
        public IUpdate UpdateStatement
        {
            get { return this.tupdate; }
        }

        public IDelete DeleteStatement
        {
            get { return this.tdelete; }
        }

        public void Use(string databaseName)
        {
            this.sql.AppendFormat(" \r\nUSE {0};",databaseName);
        }

        public void GoTo(string labelName)
        {
            this.sql.AppendFormat(" GOTO {0}",labelName);
        }

        public string DeclareColumn(string varName, System.Data.SqlDbType type)
        {
            return string.Format(" \r\n{0} {1}", varName, type.ToString());
        }

        public string DeclareVariable(string varName, System.Data.SqlDbType type)
        {
            return string.Format("DECLARE {0} AS {1}", varName, type.ToString());
        }

        public string DeclareParameter(string varName, System.Data.SqlDbType type, int size, bool isOutput, string defaultValue)
        {
            return string.Format(" {0} {1}{2}{3}={4}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "", (isOutput) ? " OUTPUT" : "", defaultValue);
        }

        public string DeclareParameter(string varName, System.Data.SqlDbType type, int size)
        {
            return string.Format(" {0} {1}{2}", varName, type.ToString(), (size != 0) ? string.Format("({0})", size) : "");
        }

        public string DeclareParameter(string varName, System.Data.SqlDbType type)
        {
            return string.Format(" {0} {1}",varName,type.ToString());
        }

        public ISQL CreateSP(string spName, params string[] paramaters)
        {
            this.sql.AppendFormat(" \r\nCREATE PROCEDURE {0} {1}", spName, Utility.GetListAsString<string>(paramaters.ToList(), ","));
            return this;
        }

        public ISQL Parentheses<T>(T sql)
        {
            this.sql.AppendFormat(" ({0})", sql.ToString());
            return this;
        }
        
        public ISQL Begin(ISQL sqlBlock)
        {
            this.sql.AppendFormat(" \r\nBEGIN\r\n {0}",sqlBlock.ToString());
            return this;
        }

        public void Begin()
        {
            this.sql.Append(" \r\nBEGIN");
        }

        public void End()
        {
            this.sql.Append(" \r\nEND");
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



        public ISQL Intersect(string statement)
        {
            this.sql.AppendFormat(" \r\nINTERSECT \r\n{0}",statement);
            return this;
        }

        public ISQL Intersect(ISQL statement)
        {
            this.sql.AppendFormat(" \r\nINTERSECT \r\n{0}",statement.ToString());
            return this;
        }

        public ISQL Intersect(ISelect statement)
        {
            this.sql.AppendFormat(" \r\nINTERSECT \r\n{0}",statement.ToString());
            return this;
        }

        public ISQL Except(string statement)
        {
            this.sql.AppendFormat(" \r\nEXCEPT \r\n{0}",statement);
            return this;
        }

        public ISQL Except(ISQL statement)
        {
            this.sql.AppendFormat(" \r\nEXCEPT \r\n{0}", statement.ToString());
            return this;
        }

        public ISQL Except(ISelect statement)
        {
            this.sql.AppendFormat(" \r\nEXCEPT \r\n{0}", statement.ToString());
            return this;
        }

        public ISQL Union(string statement)
        {
            this.sql.AppendFormat(" \r\nUNION \r\n{0}", statement);
            return this;
        }

        public ISQL Union(ISQL statement)
        {
            this.sql.AppendFormat(" \r\nUNION \r\n{0}", statement.ToString());
            return this;
        }

        public ISQL Union(ISelect statement)
        {
            this.sql.AppendFormat(" \r\nUNION \r\n{0}", statement.ToString());
            return this;
        }

        public ISQL UnionAll(string statement)
        {
            this.sql.AppendFormat(" \r\nUNION ALL \r\n{0}", statement);
            return this;
        }

        public ISQL UnionAll(ISQL statement)
        {
            this.sql.AppendFormat(" \r\nUNION ALL \r\n{0}", statement.ToString());
            return this;
        }

        public ISQL UnionAll(ISelect statement)
        {
            this.sql.AppendFormat(" \r\nUNION ALL \r\n{0}", statement.ToString());
            return this;
        }

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
            XmlNode sqlst = this.doc.SelectSingleNode(string.Format("//statement[@name=\"{0}\"]", statementName));
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
                this.sql.Insert(0, string.Format(sqlst.InnerText + " ", objs));
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

        #endregion        

        #endregion
    }
}
