﻿using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendDocumentRequest : BaseMethodRequest
    {
        public TeleChatId ChatId { get; set; }
        public InputFileRequest Document { get; set; }
        public string Caption { get; set; }
        public bool DisableNotification { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName => "sendDocument";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "caption", Caption },
                    { "disable_notification", DisableNotification },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Document?.Parse(httpData, "document");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}