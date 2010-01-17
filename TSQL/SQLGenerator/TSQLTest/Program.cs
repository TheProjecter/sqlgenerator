using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.TSQL;
using System.Xml;
using DB;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;
using Microsoft.Data.Schema.ScriptDom.Sql.ScriptGenerator;
using System.IO;


namespace TSQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL s = new SQL();
            s.SelectStatement.Select(Products.ProductID, Products.ProductName, Categories.CategoryName).From(
                DBTables.Products)
                .InnerJoin(DBTables.Categories)
                .On(Products.CategoryID).Equal(Categories.CategoryID)
                .And("@SomeVal").Equal("(select 1)")
                .Where(Products.CategoryID).Equal("12");
            Console.WriteLine(s.ToString());
            Console.WriteLine("--------------------------------");
            List<string> errors = s.Parse();
            if (errors != null && errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    Console.WriteLine("*{0}",error);
                }
            }
            else
                Console.WriteLine("No Errors");
            Console.WriteLine("--------------------------------");
            
        }   
    }

    
}
            

   