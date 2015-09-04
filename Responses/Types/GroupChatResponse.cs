namespace TeleBotDotNet.Responses.Types
{
    public class GroupChatResponse
    {
        /// <summary>
        ///     Unique identifier for this group chat
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Group name
        /// </summary>
        public string Title { get; set; }

        internal static GroupChatResponse Parse(Json data)
        {
            if (data == null || !data.Has("id") || !data.Has("title"))
            {
                return null;
            }

            return new GroupChatResponse
            {
                Id = data.Get<int>("id"),
                Title = data.Get<string>("title")
            };
        }
    }
}