using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetUserProfilePhotosResponse : BaseMethodResponse
    {
        public UserProfilePhotosResponse Result { get; set; }

        internal static GetUserProfilePhotosResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetUserProfilePhotosResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = UserProfilePhotosResponse.Parse(data.result)
            };
        }
    }
}