using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetMeResponse : BaseMethodResponse
    {
        public UserResponse Result { get; set; }

        internal static GetMeResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetMeResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = UserResponse.Parse(data.result)
            };
        }
    }
}