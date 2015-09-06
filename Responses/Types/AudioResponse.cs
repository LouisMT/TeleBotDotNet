using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class AudioResponse
    {
        public string FileId { get; private set; }
        public int Duration { get; private set; }
        public string Performer { get; private set; }
        public string Title { get; private set; }
        public string MimeType { get; private set; }
        public int? FileSize { get; private set; }

        internal static AudioResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("duration"))
            {
                return null;
            }

            return new AudioResponse
            {
                FileId = data.Get<string>("file_id"),
                Duration = data.Get<int>("duration"),
                Performer = data.Get<string>("performer"),
                Title = data.Get<string>("title"),
                MimeType = data.Get<string>("mime_type"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}