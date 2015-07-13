namespace TeleBotDotNet.Responses.Types
{
    public class DocumentResponse
    {
        public string FileId { get; set; }
        public PhotoSizeResponse Thumb { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int? FileSize { get; set; }

        internal static DocumentResponse Parse(dynamic data)
        {
            if (data == null || data.file_id == null || data.thumb == null)
            {
                return null;
            }

            return new DocumentResponse
            {
                FileId = data.file_id,
                Thumb = PhotoSizeResponse.Parse(data.thumb),
                FileName = data.file_name,
                MimeType = data.mime_type,
                FileSize = data.file_size
            };
        }
    }
}