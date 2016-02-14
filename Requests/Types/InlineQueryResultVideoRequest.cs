using System.Collections.Generic;
using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Types
{
    public class InlineQueryResultVideoRequest : BaseInlineQueryResultRequest, IInlineQueryResultRequest
    {
        public string Type => "video";

        public string Id { get; set; }
        public string VideoUrl { get; set; }
        public string MimeType { get; set; }
        public string MessageText { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool? DisableWebPagePreview { get; set; }
        public int? VideoWidth { get; set; }
        public int? VideoHeight { get; set; }
        public int? VideoDuration { get; set; }
        public string ThumbUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        internal override Dictionary<string, object> Parse()
        {
            var data = new Dictionary<string, object>
            {
                { "type", Type },
                { "id", Id },
                { "video_url", VideoUrl },
                { "mime_type", MimeType },
                { "message_text", MessageText },
                { "parse_mode", ParseMode.GetValue() },
                { "disable_web_page_preview", DisableWebPagePreview },
                { "video_width", VideoWidth },
                { "video_height", VideoHeight },
                { "video_duration", VideoDuration },
                { "thumb_url", ThumbUrl },
                { "title", Title },
                { "description", Description }
            };

            // Assume null entries are optional and remove them
            data.RemoveEmptyEntries();

            return data;
        }
    }
}
