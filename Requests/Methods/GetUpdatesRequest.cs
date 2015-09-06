using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class GetUpdatesRequest : BaseMethodRequest
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public int? Timeout { get; set; }

        internal override string MethodName => "getUpdates";

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "offset", Offset },
                    { "limit", Limit },
                    { "timeout", Timeout }
                }
            };
        }
    }
}