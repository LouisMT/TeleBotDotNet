using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetMeResponse : BaseMethodResponse
    {
        public UserResponse Result { get; private set; }

        internal static GetMeResponse Parse(Json data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetMeResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = UserResponse.Parse(data.GetJson("result"))
            };
        }
    }
}