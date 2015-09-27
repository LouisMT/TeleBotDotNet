using TeleBotDotNet.Json;
using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetFileResponse : BaseMethodResponse
    {
        public FileResponse Result { get; private set; }

        internal static GetFileResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetFileResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = FileResponse.Parse(data.GetJson("result"))
            };
        }
    }
}
