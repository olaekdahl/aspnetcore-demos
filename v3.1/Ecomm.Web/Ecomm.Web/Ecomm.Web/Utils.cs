using Ecomm.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecomm.Web
{
    public class Utils
    {
        public static ShoppingCart GetFromSession(ISession session)
        {
            byte[] data;
            ShoppingCart cart = null;
            bool b = session.TryGetValue("ShoppingCart", out data);
            if (b)
            {
                string json = Encoding.UTF8.GetString(data);
                cart = JsonSerializer.Deserialize<ShoppingCart>(json);
            }
            return cart ?? new ShoppingCart();
        }

        public static void StoreInSession(ShoppingCart cart, ISession session)
        {
            string json = JsonSerializer.Serialize(cart);
            byte[] data = Encoding.UTF8.GetBytes(json);
            session.Set("ShoppingCart", data);
        }
    }
}
