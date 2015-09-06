using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendStickerRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Sticker { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName { get; } = "sendSticker";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"chat_id", ChatId},
                    {"reply_to_message_id", ReplyToMessageId}
                }
            };

            if (Sticker != null)
            {
                Sticker.Parse(httpData, "sticker");
            }
            if (ReplyMarkup != null)
            {
                ReplyMarkup.Parse(httpData, "reply_markup");
            }

            return httpData;
        }
    }
}