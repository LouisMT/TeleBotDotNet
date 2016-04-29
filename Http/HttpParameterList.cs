using System;
using System.Collections.Generic;
using System.Globalization;

namespace TeleBotDotNet.Http
{
    internal class HttpParameterList : List<HttpParameter>
    {
        internal void Add(string key, string value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = !string.IsNullOrEmpty(value) ?
                    value : string.Empty
            });
        }

        internal void Add(string key, bool? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue && value.Value ?
                    "1" : "0"
            });
        }

        internal void Add(string key, int? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue ?
                    Convert.ToString(value.Value) : string.Empty
            });
        }

        internal void Add(string key, float? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue ?
                    Convert.ToString(value.Value, CultureInfo.InvariantCulture) : string.Empty
            });
        }

        internal void Add(string key, TeleChatId value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.ToString()
            });
        }
    }
}