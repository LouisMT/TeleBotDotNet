using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class GetMeRequest : BaseMethodRequest
    {
        internal override string MethodName => "getMe";

        internal override HttpData Parse()
        {
            return new HttpData();
        }
    }
}