
using System;
namespace DB
{
	public class Shippers
	{		
		public static string ShipperID
		{
			get
			{
				return "[dbo].[Shippers].[ShipperID]";
			}
		}
		public static string CompanyName
		{
			get
			{
				return "[dbo].[Shippers].[CompanyName]";
			}
		}
		public static string Phone
		{
			get
			{
				return "[dbo].[Shippers].[Phone]";
			}
		}
	}
}
