using TeleBotDotNet.Responses.Methods.Bases;

namespace TeleBotDotNet.Responses.Methods
{
    public class SetWebhookResponse : BaseMethodResponse
    {
        internal static SetWebhookResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new SetWebhookResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description
            };
        }
    }
}