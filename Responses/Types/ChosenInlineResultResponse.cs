using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class ChosenInlineResultResponse
    {
        public string ResultId { get; set; }
        public UserResponse From { get; set; }
        public string Query { get; set; }

        internal static ChosenInlineResultResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("result_id") || !data.Has("from") || !data.Has("query"))
            {
                return null;
            }

            return new ChosenInlineResultResponse
            {
                ResultId = data.Get<string>("result_id"),
                From = UserResponse.Parse(data.GetJson("from")),
                Query = data.Get<string>("query")
            };
        }
    }
}
