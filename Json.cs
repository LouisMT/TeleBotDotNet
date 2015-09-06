using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace TeleBotDotNet
{
    internal class Json
    {
        private readonly Dictionary<string, object> _dictionary;

        internal Json(Dictionary<string, object> dictionary)
        {
            _dictionary = dictionary;
        }

        internal T Get<T>(string name)
        {
            if (_dictionary.ContainsKey(name))
            {
                return (T)_dictionary[name];
            }

            return default(T);
        }

        internal Json GetJson(string name)
        {
            if (_dictionary.ContainsKey(name))
            {
                return new Json((Dictionary<string, object>)_dictionary[name]);
            }

            return null;
        }

        internal IEnumerable<Json> GetJsonList(string name)
        {
            if (_dictionary.ContainsKey(name))
            {
                var arrayList = (ArrayList)_dictionary[name];
                foreach (var item in arrayList)
                {
                    yield return new Json((Dictionary<string, object>)item);
                }
            }
        }

        internal DateTime? GetDateTime(string name)
        {
            if (_dictionary.ContainsKey(name))
            {
                return ((int?)_dictionary[name]).ToDateTime();
            }

            return null;
        }

        internal bool Has(string name)
        {
            return _dictionary.ContainsKey(name);
        }

        internal int Count => _dictionary.Count;

        internal static string Serialize(object input)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(input);
        }

        internal static Json Deserialize(string input)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            return new Json(javaScriptSerializer.Deserialize<Dictionary<string, object>>(input));
        }
    }
}