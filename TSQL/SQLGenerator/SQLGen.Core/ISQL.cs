using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace SQLGen.Core
{
    public interface ISQL : ICommon
    {
        ISelect SelectStatement
        {
            get;
        }
        IInsert InsertStatement
        {
            get;
        }
        IUpdate UpdateStatement
        {
            get;
        }
        IDelete DeleteStatement
        {
            get;
        }
        void Use(string databaseName);
        void GoTo(string labelName);

        string DeclareColumn(string varName,SqlDbType type,int size);
        string DeclareColumn(string varName, SqlDbType type); 
        string DeclareColumn(string varName, SqlDbType type, int size, bool allowNull);
        string DeclareColumn(string varName, SqlDbType type, int size, bool isPrimaryKey, bool isIdentity);

        string DeclareVariable(string varName,SqlDbType type,int size);
        string DeclareVariable(string varName, SqlDbType type);
        string DeclareVariables(SqlDbType type, int size, params string[] varNames);
        string SetVariable(string varName, string value);

        string DeclareParameter(string varName,SqlDbType type,int size,bool isOutput,string defaultValue);
        string DeclareParameter(string varName, SqlDbType type, int size);
        string DeclareParameter(string varName, SqlDbType type);
        
        string CreateTable(string tableName, params string[] columns);        
        string ExecuteSP(string spName, params string[] paramValues);
        ISQL CreateSP(string spName, params string[] paramaters);
        ISQL Parentheses<T>(T sql);
        void Begin();
        ISQL Begin(ISQL sqlBlock);
        void End();
        ISQL As();
        
        ICondition AppendIf(string condition);
        ICondition AppendWhile(string condition);
        
        ISQL Intersect(string statement);
        ISQL Intersect(ISQL statement);
        ISQL Intersect(ISelect statement);

        ISQL Except(string statement);
        ISQL Except(ISQL statement);
        ISQL Except(ISelect statement);

        ISQL Union(string statement);
        ISQL Union(ISQL statement);
        ISQL Union(ISelect statement);
        
        ISQL UnionAll(string statement);
        ISQL UnionAll(ISQL statement);
        ISQL UnionAll(ISelect statement);

        ISQL GroupBy(string columns);
        ISQL GroupBy(params string[] columns);

        ISQL OrderBy(string columns);
        ISQL OrderBy(params string[] columns);

        ISQL Having(string condition);
        ISQL Having(ICondition condition);
    }
}
