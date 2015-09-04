namespace TeleBotDotNet.Responses.Types
{
    public class UpdateResponse
    {
        public int UpdateId { get; set; }
        public MessageResponse Message { get; set; }

        internal static UpdateResponse Parse(Json data)
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