using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class InlineQueryResponse
    {
        public string Id { get; private set; }
        public UserResponse From { get; private set; }
        public string Query { get; private set; }
        public string Offset { get; private set; }

        internal static InlineQueryResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("id") || !data.Has("from") || !data.Has("query") || !data.Has("offset"))
            {
                return null;
            }

            return new InlineQueryResponse
            {
                Id = data.Get<string>("id"),
                From = UserResponse.Parse(data.GetJson("from")),
                Query = data.Get<string>("query"),
                Offset = data.Get<string>("offset")
            };
        }
    }
}
