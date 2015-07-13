using System.Collections.Generic;
using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class GetUpdatesResponse : BaseMethodResponse
    {
        public List<UpdateResponse> Result { get; set; }

        internal static GetUpdatesResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            var getUpdatesResponse = new GetUpdatesResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = new List<UpdateResponse>()
            };

            foreach (var result in data.result)
            {
                getUpdatesResponse.Result.Add(UpdateResponse.Parse(result));
            }

            return getUpdatesResponse;
        }
    }
}