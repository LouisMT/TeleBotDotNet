namespace TeleBotDotNet.Responses.Types
{
    public class StickerResponse
    {
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public PhotoSizeResponse Thumb { get; set; }
        public int? FileSize { get; set; }

        internal static StickerResponse Parse(Json data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("width") || !data.Has("height") || !data.Has("thumb"))
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