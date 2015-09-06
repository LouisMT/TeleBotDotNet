using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class StickerResponse
    {
        public string FileId { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public PhotoSizeResponse Thumb { get; private set; }
        public int? FileSize { get; private set; }

        internal static StickerResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("width") || !data.Has("height"))
            {
                return null;
            }

            return new StickerResponse
            {
                FileId = data.Get<string>("file_id"),
                Width = data.Get<int>("width"),
                Height = data.Get<int>("height"),
                Thumb = PhotoSizeResponse.Parse(data.GetJson("thumb")),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}