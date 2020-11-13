using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Web.Models;

namespace EComm.Web.Helpers
{
    public static class SessionExtension
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            byte[] data;
            var value = Activator.CreateInstance(typeof(T));
            bool success = session.TryGetValue(key, out data);
            if(success)
            {
                string json = Encoding.UTF8.GetString(data);
                value = JsonSerializer.Deserialize<UserModel>(json);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static void SetObject<T>(this ISession session, string key, object value)
        {
            var obj = Activator.CreateInstance(typeof(T));
            obj = value;
            string json = JsonSerializer.Serialize(obj);
            byte[] data = Encoding.UTF8.GetBytes(json);
            session.Set(key, data);
        }
    }
}
