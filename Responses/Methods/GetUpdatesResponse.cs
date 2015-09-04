using System.Collections.Generic;
using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetUpdatesResponse : BaseMethodResponse
    {
        public List<UpdateResponse> Result { get; set; }

        internal static GetUpdatesResponse Parse(Json data)
        {
            if (data == null)
            {
                return null;
            }

            var getUpdatesResponse = new GetUpdatesResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = new List<UpdateResponse>()
            };

            foreach (var result in data.GetJsonList("result"))
            {
                getUpdatesResponse.Result.Add(UpdateResponse.Parse(result));
            }

            return getUpdatesResponse;
        }
    }
}