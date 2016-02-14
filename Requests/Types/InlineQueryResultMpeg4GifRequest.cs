using System.Collections.Generic;
using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Types
{
    public class InlineQueryResultMpeg4GifRequest : BaseInlineQueryResultRequest, IInlineQueryResultRequest
    {
        public string Type => "mpeg4_gif";

        public string Id { get; set; }
        public string Mpeg4Url { get; set; }
        public int? Mpeg4Width { get; set; }
        public int? Mpeg4Height { get; set; }
        public string ThumbUrl { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string MessageText { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool? DisableWebPagePreview { get; set; }

        internal override Dictionary<string, object> Parse()
        {
            var data = new Dictionary<string, object>
            {
                { "type", Type },
                { "id", Id },
                { "mpeg4_url", Mpeg4Url },
                { "mpeg4_width", Mpeg4Width },
                { "mpeg4_height", Mpeg4Height },
                { "thumb_url", ThumbUrl },
                { "title", Title },
                { "caption", Caption },
                { "message_text", MessageText },
                { "parse_mode", ParseMode.GetValue() },
                { "disable_web_page_preview", DisableWebPagePreview }
            };

            // Assume null entries are optional and remove them
            data.RemoveEmptyEntries();

            return data;
        }
    }
}
