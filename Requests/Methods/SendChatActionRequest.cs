﻿using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendChatActionRequest : BaseMethodRequest
    {
        public TeleChatId ChatId { get; set; }
        public ActionRequest Action { get; set; }

        internal override string MethodName => "sendChatAction";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId }
                }
            };

            Action?.Parse(httpData, "action");

            return httpData;
        }
    }
}