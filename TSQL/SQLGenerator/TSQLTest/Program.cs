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
                DBTables.Products).InnerJoin(DBTables.Categories).On(Products.CategoryID).Equal(Categories.CategoryID).And("@SomeVal").Equal("(select 1)");
            Console.WriteLine(s.ToString());
            Console.WriteLine("--------------------------------");
            TSql100Parser parser = new TSql100Parser(false);
            IScriptFragment fragment;
            IList<ParseError> errors;
            fragment = parser.Parse(new StringReader(s.ToString()), out errors);
            if (errors != null && errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    Console.WriteLine("*{0}",error.Message);
                }
            }
            else
                Console.WriteLine("No Errors");
            Console.WriteLine("--------------------------------");
            
        }   
    }

    
}
            

   