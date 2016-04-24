using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendMessageRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public string Text { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool DisableWebPagePreview { get; set; }
        public bool DisableNotification { get; set; }
        public int? ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName => "sendMessage";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "text", Text },
                    { "parse_mode", ParseMode.GetValue() },
                    { "disable_web_page_preview", DisableWebPagePreview },
                    { "disable_notification", DisableNotification },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}