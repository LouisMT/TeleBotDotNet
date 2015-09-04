using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendAudioResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; set; }

        internal static SendAudioResponse Parse(Json data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendAudioResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = MessageResponse.Parse(data.GetJson("result"))
            };
        }
    }
}