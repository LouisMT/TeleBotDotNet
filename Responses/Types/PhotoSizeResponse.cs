namespace TeleBotDotNet.Responses.Types
{
    public class PhotoSizeResponse
    {
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int? FileSize { get; set; }

        internal static PhotoSizeResponse Parse(Json data)
        {
            if (data == null || !data.Has("file_id") || data.Has("width") || data.Has("height"))
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