﻿using TeleBotDotNet.Http;
using TeleBotDotNet.Json;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ReplyKeyboardHideRequest : BaseTypeRequest
    {
        public bool HideKeyboard => true;

        public bool Selective { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, JsonData.Serialize(new
            {
                hide_keyboard = HideKeyboard,
                selective = Selective
            }));
        }
    }
}