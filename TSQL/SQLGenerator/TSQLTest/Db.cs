using System;
namespace DBTables
{
    public class Db
    {
        public static string Basket
        {
            get
            {
                return "Basket";
            }
        }
        public static string BasketProduct
        {
            get
            {
                return "BasketProduct";
            }
        }
        public static string Category
        {
            get
            {
                return "Category";
            }
        }
        public static string Order
        {
            get
            {
                return "Order";
            }
        }
        public static string OrderProduct
        {
            get
            {
                return "OrderProduct";
            }
        }
        public static string Product
        {
            get
            {
                return "Product";
            }
        }
    }

    public class Basket
    {
        public static string Bsk_ID
        {
            get
            {
                return "Basket.Bsk_ID";
            }
        }
        public static string Bsk_Date
        {
            get
            {
                return "Basket.Bsk_Date";
            }
        }
        public static string Usr_ID
        {
            get
            {
                return "Basket.Usr_ID";
            }
        }
    }
    public class BasketProduct
    {
        public static string Bsk_ID
        {
            get
            {
                return "BasketProduct.Bsk_ID";
            }
        }
        public static string Pdc_ID
        {
            get
            {
                return "BasketProduct.Pdc_ID";
            }
        }
        public static string Qty
        {
            get
            {
                return "BasketProduct.Qty";
            }
        }
    }
    public class Category
    {
        public static string Ctr_ID
        {
            get
            {
                return "Category.Ctr_ID";
            }
        }
        public static string Ctr_Name
        {
            get
            {
                return "Category.Ctr_Name";
            }
        }
    }
    public class Order
    {
        public static string Or_ID
        {
            get
            {
                return "Order.Or_ID";
            }
        }
        public static string Or_Date
        {
            get
            {
                return "Order.Or_Date";
            }
        }
    }
    public class OrderProduct
    {
        public static string Pdc_ID
        {
            get
            {
                return "OrderProduct.Pdc_ID";
            }
        }
        public static string Or_ID
        {
            get
            {
                return "OrderProduct.Or_ID";
            }
        }
        public static string Qty
        {
            get
            {
                return "OrderProduct.Qty";
            }
        }
    }
    public class Product
    {
        public static string Pdc_ID
        {
            get
            {
                return "Product.Pdc_ID";
            }
        }
        public static string Pdc_Name
        {
            get
            {
                return "Product.Pdc_Name";
            }
        }
        public static string Pdc_Price
        {
            get
            {
                return "Product.Pdc_Price";
            }
        }
        public static string Pdc_ImageUrl
        {
            get
            {
                return "Product.Pdc_ImageUrl";
            }
        }
        public static string Pdc_Description
        {
            get
            {
                return "Product.Pdc_Description";
            }
        }
        public static string Ctr_ID
        {
            get
            {
                return "Product.Ctr_ID";
            }
        }
    }

    public class DbProcs
    {
        public static string Basket_GetByUserID
        {
            get
            {
                return "Basket_GetByUserID";
            }
        }
        public static string Category_GetAllPaged
        {
            get
            {
                return "Category_GetAllPaged";
            }
        }
        public static string Product_GetAllPaged
        {
            get
            {
                return "Product_GetAllPaged";
            }
        }
        public static string Product_GetByBasketID
        {
            get
            {
                return "Product_GetByBasketID";
            }
        }
        public static string Product_GetByCategoryID
        {
            get
            {
                return "Product_GetByCategoryID";
            }
        }
        public static string Product_GetByCategoryIDPaged
        {
            get
            {
                return "Product_GetByCategoryIDPaged";
            }
        }
        public static string Product_GetByOrderID
        {
            get
            {
                return "Product_GetByOrderID";
            }
        }
    }
}

