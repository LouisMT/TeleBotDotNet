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
            return _dictionary.ContainsKey(name) ?
                new Json((Dictionary<string, object>)_dictionary[name]) : null;
        }

        internal IEnumerable<Json> GetJsonList(string name)
        {
            if (!_dictionary.ContainsKey(name))
            {
                yield break;
            }

            var arrayList = (ArrayList)_dictionary[name];
            foreach (var item in arrayList)
            {
                yield return new Json((Dictionary<string, object>)item);
            }
        }

        internal DateTime? GetDateTime(string name)
        {
            return _dictionary.ContainsKey(name) ?
                ((int?)_dictionary[name]).ToDateTime() : null;
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