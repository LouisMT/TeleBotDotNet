using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendVideoResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; set; }

        internal static SendVideoResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendVideoResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = MessageResponse.Parse(data.result)
            };
        }
    }
}