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
            s.SelectStatement.Select(Products.ProductID, Products.ProductName)
                .From(DBTables.Products)
                .InnerJoin(DBTables.Categories)
                .On(Categories.CategoryID).Equal(Products.CategoryID)
                .Where(Products.Discontinued).Equal("'true'");            
            TSelect sel = new TSelect();
            sel.Select(Products.ProductID, Products.ProductName)
                .From(DBTables.Products)
                .Where(Products.ProductName).Like("p%");
            s.Intersect(sel);
            
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
            

   