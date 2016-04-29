using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using TeleBotDotNet.Extensions;

namespace TeleBotDotNet.Json
{
    internal class JsonData
    {
        private readonly Dictionary<string, object> _dictionary;

        internal JsonData(Dictionary<string, object> dictionary)
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

        internal JsonData GetJson(string name)
        {
            return _dictionary.ContainsKey(name) ?
                new JsonData((Dictionary<string, object>)_dictionary[name]) : null;
        }

        internal IEnumerable<JsonData> GetJsonList(string name)
        {
            if (!_dictionary.ContainsKey(name))
            {
                yield break;
            }

            var arrayList = (ArrayList)_dictionary[name];
            foreach (var item in arrayList)
            {
                yield return new JsonData((Dictionary<string, object>)item);
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

        internal static JsonData Deserialize(string input)
        {
            try
            {
                var javaScriptSerializer = new JavaScriptSerializer();
                return new JsonData(javaScriptSerializer.Deserialize<Dictionary<string, object>>(input));
            }
            catch (Exception exception)
            {
                throw new JsonException(input, exception);
            }
        }
    }
}