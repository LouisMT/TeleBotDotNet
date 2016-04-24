using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendVenueRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string FoursquareId { get; set; }
        public bool DisableNotification { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName => "sendVenue";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "latitude", Latitude },
                    { "longitude", Longitude },
                    { "title", Title },
                    { "address", Address },
                    { "foursquare_id", FoursquareId },
                    { "disable_notification", DisableNotification },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}
