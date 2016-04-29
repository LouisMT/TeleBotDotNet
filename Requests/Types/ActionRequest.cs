using TeleBotDotNet.Extensions;
using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ActionRequest : BaseTypeRequest
    {
        public ChatAction Action { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, Action.GetValue());
        }
    }
}