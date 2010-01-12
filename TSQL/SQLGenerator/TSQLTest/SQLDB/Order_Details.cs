
using System;
namespace DB
{
	public class Order_Details
	{		
		public static string OrderID
		{
			get
			{
				return "[dbo].[Order Details].[OrderID]";
			}
		}
		public static string ProductID
		{
			get
			{
				return "[dbo].[Order Details].[ProductID]";
			}
		}
		public static string UnitPrice
		{
			get
			{
				return "[dbo].[Order Details].[UnitPrice]";
			}
		}
		public static string Quantity
		{
			get
			{
				return "[dbo].[Order Details].[Quantity]";
			}
		}
		public static string Discount
		{
			get
			{
				return "[dbo].[Order Details].[Discount]";
			}
		}
	}
}
