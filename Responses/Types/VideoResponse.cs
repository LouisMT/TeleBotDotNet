using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class VideoResponse
    {
        public int FileId { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Duration { get; private set; }
        public PhotoSizeResponse Thumb { get; private set; }
        public string MimeType { get; private set; }
        public int? FileSize { get; private set; }

        internal static VideoResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("width") || !data.Has("height") || !data.Has("duration"))
            {
                return null;
            }

            return new VideoResponse
            {
                FileId = data.Get<int>("file_id"),
                Width = data.Get<int>("width"),
                Height = data.Get<int>("height"),
                Duration = data.Get<int>("duration"),
                Thumb = PhotoSizeResponse.Parse(data.GetJson("thumb")),
                MimeType = data.Get<string>("mime_type"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}