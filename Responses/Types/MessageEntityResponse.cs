using System;
using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class MessageEntityResponse
    {
        public MessageEntityType Type { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }
        public string Url { get; private set; }

        internal static MessageEntityResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("type") || !data.Has("offset") || !data.Has("length"))
            {
                return null;
            }

            var messageEntityResponse = new MessageEntityResponse
            {
                Offset = data.Get<int>("offset"),
                Length = data.Get<int>("length"),
                Url = data.Get<string>("url")
            };

            // Replace (remove) underscores to match the enum's name.
            var messageEntityType = data.Get<string>("type").Replace("_", string.Empty);
            messageEntityResponse.Type = (MessageEntityType)Enum.Parse(typeof(MessageEntityType), messageEntityType, true);

            return messageEntityResponse;
        }
    }
}
