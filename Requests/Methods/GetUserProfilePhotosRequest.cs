using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class GetUserProfilePhotosRequest : BaseMethodRequest
    {
        public int UserId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        internal override string MethodName => "getUserProfilePhotos";

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"user_id", UserId},
                    {"offset", Offset},
                    {"limit", Limit}
                }
            };
        }
    }
}