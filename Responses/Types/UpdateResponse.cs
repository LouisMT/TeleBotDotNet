namespace TeleBotDotNet.Responses.Types
{
    public class UpdateResponse
    {
        public int UpdateId { get; set; }
        public MessageResponse Message { get; set; }

        internal static UpdateResponse Parse(dynamic data)
        {
            if (data == null || data.update_id == null)
            {
                return null;
            }

            return new UpdateResponse
            {
                UpdateId = data.update_id,
                Message = MessageResponse.Parse(data.message)
            };
        }
    }
}