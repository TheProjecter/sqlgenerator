using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.TSQL;
using System.Xml;


namespace TSQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL s = new SQL();
            s.Use("MyDB");
            s.SelectStatement.Select("*").From("MyTable").As("mt").InnerJoin("OtherTable").As("ot").On("ot.PK").Equal("mt.FK");
            s.Close();
            s.Close("GO");
            s.AppendIf("@c").Equal("3");
            s.Begin();
            TFullTextSearch search = new TFullTextSearch();
            TFullTextSearchCondition cond = new TFullTextSearchCondition();
            cond.SimpleTerm("\"sometext\"").AndNot("\"thatword\"");
            s.InsertStatement.InsertInto("Customers").SubQuery.Select("*").From().ContainsTable("Suppliers", cond, "Description").Where().Contians("con",null,"Desc");
            s.End();
            Console.WriteLine(s.ToString());
        }   
    }

    
}
            

   