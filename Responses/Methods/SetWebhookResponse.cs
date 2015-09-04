using TeleBotDotNet.Responses.Methods.Bases;

namespace TeleBotDotNet.Responses.Methods
{
    public class SetWebhookResponse : BaseMethodResponse
    {
        internal static SetWebhookResponse Parse(Json data)
        {
            if (data == null)
            {
                return null;
            }

            return new SetWebhookResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description")
            };
        }
    }
}