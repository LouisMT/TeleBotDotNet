namespace TeleBotDotNet.Responses.Types
{
    public class AudioResponse
    {
        public string FileId { get; set; }
        public int Duration { get; set; }
        public string MimeType { get; set; }
        public int? FileSize { get; set; }

        internal static AudioResponse Parse(Json data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("duration"))
            {
                return null;
            }

            return new AudioResponse
            {
                FileId = data.Get<string>("file_id"),
                Duration = data.Get<int>("duration"),
                MimeType = data.Get<string>("mime_type"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}