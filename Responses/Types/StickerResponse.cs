namespace TeleBotDotNet.Responses.Types
{
    public class StickerResponse
    {
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public PhotoSizeResponse Thumb { get; set; }
        public int? FileSize { get; set; }

        internal static StickerResponse Parse(dynamic data)
        {
            if (data == null || data.file_id == null || data.width == null || data.height == null || data.thumb == null)
            {
                return null;
            }

            return new StickerResponse
            {
                FileId = data.file_id,
                Width = data.width,
                Height = data.height,
                Thumb = PhotoSizeResponse.Parse(data.thumb),
                FileSize = data.file_size
            };
        }
    }
}