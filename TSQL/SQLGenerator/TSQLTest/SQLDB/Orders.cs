
using System;
namespace DB
{
	public class Orders
	{		
		public static string OrderID
		{
			get
			{
				return "[dbo].[Orders].[OrderID]";
			}
		}
		public static string CustomerID
		{
			get
			{
				return "[dbo].[Orders].[CustomerID]";
			}
		}
		public static string EmployeeID
		{
			get
			{
				return "[dbo].[Orders].[EmployeeID]";
			}
		}
		public static string OrderDate
		{
			get
			{
				return "[dbo].[Orders].[OrderDate]";
			}
		}
		public static string RequiredDate
		{
			get
			{
				return "[dbo].[Orders].[RequiredDate]";
			}
		}
		public static string ShippedDate
		{
			get
			{
				return "[dbo].[Orders].[ShippedDate]";
			}
		}
		public static string ShipVia
		{
			get
			{
				return "[dbo].[Orders].[ShipVia]";
			}
		}
		public static string Freight
		{
			get
			{
				return "[dbo].[Orders].[Freight]";
			}
		}
		public static string ShipName
		{
			get
			{
				return "[dbo].[Orders].[ShipName]";
			}
		}
		public static string ShipAddress
		{
			get
			{
				return "[dbo].[Orders].[ShipAddress]";
			}
		}
		public static string ShipCity
		{
			get
			{
				return "[dbo].[Orders].[ShipCity]";
			}
		}
		public static string ShipRegion
		{
			get
			{
				return "[dbo].[Orders].[ShipRegion]";
			}
		}
		public static string ShipPostalCode
		{
			get
			{
				return "[dbo].[Orders].[ShipPostalCode]";
			}
		}
		public static string ShipCountry
		{
			get
			{
				return "[dbo].[Orders].[ShipCountry]";
			}
		}
	}
}
