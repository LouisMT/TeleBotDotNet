using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class FileResponse
    {
        public string FileId { get; private set; }
        public int? FileSize { get; private set; }
        public string FilePath { get; private set; }

        internal static FileResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id"))
            {
                return null;
            }

            return new FileResponse
            {
                FileId = data.Get<string>("file_id"),
                FileSize = data.Get<int?>("file_size"),
                FilePath = data.Get<string>("file_path")
            };
        }
    }
}
