using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class UpdateResponse
    {
        public int UpdateId { get; private set; }
        public MessageResponse Message { get; private set; }

        internal static UpdateResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("update_id"))
            {
                return null;
            }

            return new UpdateResponse
            {
                UpdateId = data.Get<int>("update_id"),
                Message = MessageResponse.Parse(data.GetJson("message"))
            };
        }
    }
}