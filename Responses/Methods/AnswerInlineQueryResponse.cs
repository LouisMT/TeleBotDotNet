using TeleBotDotNet.Json;
using TeleBotDotNet.Responses.Methods.Bases;

namespace TeleBotDotNet.Responses.Methods
{
    public class AnswerInlineQueryResponse : BaseMethodResponse
    {
        internal static AnswerInlineQueryResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new AnswerInlineQueryResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description")
            };
        }
    }
}
