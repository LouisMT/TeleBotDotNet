namespace TeleBotDotNet.Responses.Types
{
    public class PhotoSizeResponse
    {
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int? FileSize { get; set; }

        internal static PhotoSizeResponse Parse(dynamic data)
        {
            if (data == null || data.file_id == null || data.width == null || data.height == null)
            {
                return null;
            }

            return new PhotoSizeResponse
            {
                FileId = data.file_id,
                Width = data.width,
                Height = data.height,
                FileSize = data.file_size
            };
        }
    }
}