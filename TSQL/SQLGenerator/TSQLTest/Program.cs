using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.TSQL;
using System.Xml;
using DBTables;


namespace TSQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL s = new SQL();
            s.Use("MyDB");
            s.SelectStatement.Select(Product.Pdc_ID,Product.Pdc_Name,Category.Ctr_Name).From(Db.Product).InnerJoin(Db.Category).On(Product.Ctr_ID).Equal(Category.Ctr_ID);
            s.Close();
            s.Close("GO");
            s.AppendIf("@c").Equal("3");
            s.Begin();
            TFullTextSearch search = new TFullTextSearch();
            TFullTextSearchCondition cond = new TFullTextSearchCondition();
            cond.SimpleTerm("\"sometext\"").AndNot("\"thatword\"");
            s.InsertStatement.InsertInto(Db.Category).SubQuery.Select("*").From().ContainsTable(Db.Category, cond,Category.Ctr_Name).Where().Contians("con",null,"Desc");
            s.Append(s.ExecuteSP(DbProcs.Basket_GetByUserID, "2"));
            s.Close();
            s.End();
            Console.WriteLine(s.ToString());
        }   
    }

    
}
            

   