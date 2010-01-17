using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SQLGen.Core
{
    public interface ICommon
    {
        void LoadXml(string xml);
        void LoadXml(XmlDocument xdoc);
        void LoadXmlFromFile(string filePath);

        void AppendSqlFromXml(string statementName, params string[] objs);
        void AppendSqlFromXmlHeader(params string[] objs);
        void AppendSqlFromXmlFooter(params string[] objs);
        void Append(string statement);
        List<string> Parse();
        void SaveTo(string filePath);

        void Close();
        void Close(string separator);
    }
}
