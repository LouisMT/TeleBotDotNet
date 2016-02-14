using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class UpdateResponse
    {
        public int UpdateId { get; private set; }
        public MessageResponse Message { get; private set; }
        public InlineQueryResponse InlineQuery { get; private set; }
        public ChosenInlineResultResponse ChosenInlineResult { get; private set; }

        internal static UpdateResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("update_id"))
            {
                return null;
            }

            return new UpdateResponse
            {
                UpdateId = data.Get<int>("update_id"),
                Message = MessageResponse.Parse(data.GetJson("message")),
                InlineQuery = InlineQueryResponse.Parse(data.GetJson("inline_query")),
                ChosenInlineResult = ChosenInlineResultResponse.Parse(data.GetJson("chosen_inline_result"))
            };
        }
    }
}