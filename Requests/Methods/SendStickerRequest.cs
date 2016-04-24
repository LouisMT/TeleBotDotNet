using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendStickerRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Sticker { get; set; }
        public bool DisableNotification { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName => "sendSticker";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "disable_notification", DisableNotification },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Sticker?.Parse(httpData, "sticker");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}