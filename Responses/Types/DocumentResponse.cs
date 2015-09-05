namespace TeleBotDotNet.Responses.Types
{
    public class DocumentResponse
    {
        public string FileId { get; set; }
        public PhotoSizeResponse Thumb { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int? FileSize { get; set; }

        internal static DocumentResponse Parse(Json data)
        {
            if (data == null || !data.Has("file_id"))
            {
                return null;
            }

            return new DocumentResponse
            {
                FileId = data.Get<string>("file_id"),
                Thumb = PhotoSizeResponse.Parse(data.GetJson("thumb")),
                FileName = data.Get<string>("file_name"),
                MimeType = data.Get<string>("mime_type"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}