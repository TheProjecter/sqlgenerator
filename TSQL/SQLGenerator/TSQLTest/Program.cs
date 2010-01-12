using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.TSQL;
using System.Xml;
using DB;


namespace TSQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL s = new SQL();
            s.SelectStatement.Select(Products.ProductID, Products.ProductName, Categories.CategoryName).From(
                DBTables.Products).InnerJoin(DBTables.Categories).On(Products.CategoryID).Equal(Categories.CategoryID);
            Console.WriteLine(s.ToString());
        }   
    }

    
}
            

   