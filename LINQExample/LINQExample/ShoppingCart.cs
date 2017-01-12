using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class Product
    {
        string _item;
        public string Item
        {
            get
            {
                return Item = _item;
            }
            set
            {
                _item = value;
            }
        }
        string _itemType;
        public string ItemType
        {
            get
            {
                return ItemType = _itemType;
            }
            set
            {
                _itemType = value;
            }
        }


        double _qty;
        public double Qty
        {
            get
            {
                return Qty = _qty;
            }
            set
            {
                _qty = value;
            }
        }

        double _price;
        public double Price
        {
            get
            {
                //Console.WriteLine($"Checking Price of item:{Item}");
                return Price = _price;
            }
            set
            {
                _price = value;
            }
        }

        public Product(String iItem, string iItemType, double iqty, double iprice)
        {
            Item = iItem;
            ItemType = iItemType;
            Qty = iqty;
            Price = iprice;
        }

    }

    static class ShoppingCart
    {
        public static List<Product> GetshoppingCart()
        {
            List<Product> listOfProduct = new List<Product>();
            listOfProduct.Add(new Product("Orange","Veg & Fruit", 3, 35));
            listOfProduct.Add(new Product("Apple", "Veg & Fruit", 5, 100));
            listOfProduct.Add(new Product("Surf", "Detergent", 1, 240));
            listOfProduct.Add(new Product("Milk", "Dairy", 2, 120));
            listOfProduct.Add(new Product("Cheese", "Dairy", 1, 500));


            return listOfProduct;
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> source ,
                                                   Func<Product,bool> predicate)
        {

            List<Product> l1 = new List<Product>();
            foreach (var item in source)
            {
                if(predicate(item))
                {
                    l1.Add(item);
                }
            }

            return l1;
        }

        public static IEnumerable<Product> FilterLazy(this IEnumerable<Product> source,
                                           Func<Product, bool> predicate)
        {

            
            foreach (var item in source)
            {
                if (predicate(item))
                {
                   yield return item;
                }
            }

            
        }
    }
}
