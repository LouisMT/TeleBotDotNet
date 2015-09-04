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

        internal static VideoResponse Parse(Json data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("width") || !data.Has("height") || !data.Has("duration") || !data.Has("thumb"))
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
                FileSize = data.Get<int?>("file_size"),
                Caption = data.Get<string>("caption")
            };
        }
    }
}