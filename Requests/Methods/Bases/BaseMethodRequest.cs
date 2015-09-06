using TeleBotDotNet.Http;

namespace TeleBotDotNet.Requests.Methods.Bases
{
    public abstract class BaseMethodRequest
    {
        internal abstract string MethodName { get; }

        internal abstract HttpData Parse();
    }
}