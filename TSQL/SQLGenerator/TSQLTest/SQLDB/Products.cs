
using System;
namespace DB
{
	public class Products
	{		
		public static string ProductID
		{
			get
			{
				return "[dbo].[Products].[ProductID]";
			}
		}
		public static string ProductName
		{
			get
			{
				return "[dbo].[Products].[ProductName]";
			}
		}
		public static string SupplierID
		{
			get
			{
				return "[dbo].[Products].[SupplierID]";
			}
		}
		public static string CategoryID
		{
			get
			{
				return "[dbo].[Products].[CategoryID]";
			}
		}
		public static string QuantityPerUnit
		{
			get
			{
				return "[dbo].[Products].[QuantityPerUnit]";
			}
		}
		public static string UnitPrice
		{
			get
			{
				return "[dbo].[Products].[UnitPrice]";
			}
		}
		public static string UnitsInStock
		{
			get
			{
				return "[dbo].[Products].[UnitsInStock]";
			}
		}
		public static string UnitsOnOrder
		{
			get
			{
				return "[dbo].[Products].[UnitsOnOrder]";
			}
		}
		public static string ReorderLevel
		{
			get
			{
				return "[dbo].[Products].[ReorderLevel]";
			}
		}
		public static string Discontinued
		{
			get
			{
				return "[dbo].[Products].[Discontinued]";
			}
		}
	}
}
