using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_diagram_lab
{
    public class Product : IProduct
    {

        public Product()
        {
            price = 0;
            name = "";
        }

        private int price;
        private string name;

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0)
                    throw new WrongPriceException();
                price = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        override public String ToString()
        {
            return $"Price {Price}; Name {Name}";
        }
    }


    public class WrongPriceException: Exception
    {
       public WrongPriceException():this("setting wrong price")
        {

        }
        public WrongPriceException(string description): this(description,null)
        {

        }
        public WrongPriceException(string description, Exception parent)
        {

        }
    }
}