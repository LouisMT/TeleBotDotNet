using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class PhotoSizeResponse
    {
        public string FileId { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int? FileSize { get; private set; }

        internal static PhotoSizeResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("width") || !data.Has("height"))
            {
                return null;
            }

            return new PhotoSizeResponse
            {
                FileId = data.Get<string>("file_id"),
                Width = data.Get<int>("width"),
                Height = data.Get<int>("height"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}