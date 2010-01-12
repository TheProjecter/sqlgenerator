
using System;
namespace DB
{
	public class Categories
	{		
		public static string CategoryID
		{
			get
			{
				return "[dbo].[Categories].[CategoryID]";
			}
		}
		public static string CategoryName
		{
			get
			{
				return "[dbo].[Categories].[CategoryName]";
			}
		}
		public static string Description
		{
			get
			{
				return "[dbo].[Categories].[Description]";
			}
		}
		public static string Picture
		{
			get
			{
				return "[dbo].[Categories].[Picture]";
			}
		}
	}
}
