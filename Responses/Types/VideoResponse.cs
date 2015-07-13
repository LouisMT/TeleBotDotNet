namespace TeleBotDotNet.Responses.Types
{
    public class VideoResponse
    {
        public int FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public PhotoSizeResponse Thumb { get; set; }
        public string MimeType { get; set; }
        public int? FileSize { get; set; }
        public string Caption { get; set; }

        internal static VideoResponse Parse(dynamic data)
        {
            if (data == null || data.file_id == null || data.width == null || data.height == null || data.duration == null || data.thumb == null)
            {
                return null;
            }

            return new VideoResponse
            {
                FileId = data.file_id,
                Width = data.width,
                Height = data.height,
                Duration = data.duration,
                Thumb = PhotoSizeResponse.Parse(data.thumb),
                MimeType = data.mime_type,
                FileSize = data.file_size,
                Caption = data.caption
            };
        }
    }
}