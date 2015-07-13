using System.Web.Helpers;
using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ForceReplyRequest : BaseTypeRequest
    {
        public bool ForceReply
        {
            get { return true; }
        }

        public bool Selective { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, Json.Encode(new
            {
                force_reply = ForceReply,
                selective = Selective
            }));
        }
    }
}