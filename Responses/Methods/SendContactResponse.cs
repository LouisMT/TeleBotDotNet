using TeleBotDotNet.Json;
using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendContactResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; private set; }

        internal static SendContactResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendContactResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = MessageResponse.Parse(data.GetJson("result"))
            };
        }
    }
}
