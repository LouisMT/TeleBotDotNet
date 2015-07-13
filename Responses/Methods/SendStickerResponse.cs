using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendStickerResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; set; }

        internal static SendStickerResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendStickerResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = MessageResponse.Parse(data.result)
            };
        }
    }
}