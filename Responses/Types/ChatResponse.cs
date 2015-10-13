using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class ChatResponse
    {
        public int Id { get; private set; }
        public ChatType Type { get; private set; }
        public string Title { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        internal static ChatResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("id") || !data.Has("type"))
            {
                return null;
            }

            var chatResponse = new ChatResponse
            {
                Id = data.Get<int>("id"),
                Title = data.Get<string>("title"),
                UserName = data.Get<string>("username"),
                FirstName = data.Get<string>("first_name"),
                LastName = data.Get<string>("last_name")
            };

            switch (data.Get<string>("type"))
            {
                case "private":
                    chatResponse.Type = ChatType.Private;
                    break;

                case "group":
                    chatResponse.Type = ChatType.Group;
                    break;

                case "channel":
                    chatResponse.Type = ChatType.Channel;
                    break;
            }

            return chatResponse;
        }
    }
}
