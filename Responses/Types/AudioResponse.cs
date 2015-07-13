namespace TeleBotDotNet.Responses.Types
{
    public class AudioResponse
    {
        public string FileId { get; set; }
        public int Duration { get; set; }
        public string MimeType { get; set; }
        public int? FileSize { get; set; }

        internal static AudioResponse Parse(dynamic data)
        {
            if (data == null || data.file_id == null || data.duration == null)
            {
                return null;
            }

            return new AudioResponse
            {
                FileId = data.file_id,
                Duration = data.duration,
                MimeType = data.mime_type,
                FileSize = data.file_size
            };
        }
    }
}