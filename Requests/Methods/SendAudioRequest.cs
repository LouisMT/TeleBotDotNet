﻿using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendAudioRequest : BaseMethodRequest
    {
        public TeleChatId ChatId { get; set; }
        public InputFileRequest Audio { get; set; }
        public int? Duration { get; set; }
        public string Performer { get; set; }
        public string Title { get; set; }
        public bool DisableNotification { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName => "sendAudio";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "duration", Duration },
                    { "performer", Performer },
                    { "title", Title },
                    { "disable_notification", DisableNotification },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Audio?.Parse(httpData, "audio");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}