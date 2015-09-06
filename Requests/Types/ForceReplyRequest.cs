using TeleBotDotNet.Http;
using TeleBotDotNet.Json;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ForceReplyRequest : BaseTypeRequest
    {
        public bool ForceReply => true;

        public bool Selective { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, JsonData.Serialize(new
            {
                force_reply = ForceReply,
                selective = Selective
            }));
        }
    }
}