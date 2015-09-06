using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class ForwardMessageResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; private set; }

        internal static ForwardMessageResponse Parse(Json data)
        {
            if (data == null)
            {
                return null;
            }

            return new ForwardMessageResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = MessageResponse.Parse(data.GetJson("result"))
            };
        }
    }
}