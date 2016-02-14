using System.Collections.Generic;

namespace TeleBotDotNet.Requests.Types.Bases
{
    public abstract class BaseInlineQueryResultRequest
    {
        internal abstract Dictionary<string, object> Parse();
    }
}
