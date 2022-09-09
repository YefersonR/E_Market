using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace E_Market.Core.Application.Helpers
{
    public static class SessionHelper
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));

        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default;
            }
            return  JsonConvert.DeserializeObject<T>(value);
        }
    }
}
