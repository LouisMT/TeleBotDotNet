using TeleBotDotNet.Json;
using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetUserProfilePhotosResponse : BaseMethodResponse
    {
        public UserProfilePhotosResponse Result { get; private set; }

        internal static GetUserProfilePhotosResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetUserProfilePhotosResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = UserProfilePhotosResponse.Parse(data.GetJson("result"))
            };
        }
    }
}