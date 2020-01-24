using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Web.Models
{
    public class ShoppingCart
    {
        List<string> items;

        public ShoppingCart()
        {
            items = new List<string>();
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public List<string> GetItems()
        {
            return items;
        }
    }
}
