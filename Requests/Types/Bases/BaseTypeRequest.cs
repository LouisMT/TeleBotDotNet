using TeleBotDotNet.Http;

namespace TeleBotDotNet.Requests.Types.Bases
{
    public abstract class BaseTypeRequest
    {
        internal abstract void Parse(HttpData httpData, string key);
    }
}