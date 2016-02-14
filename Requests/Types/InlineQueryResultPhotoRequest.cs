using System.Collections.Generic;
using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Types
{
    public class InlineQueryResultPhotoRequest : BaseInlineQueryResultRequest, IInlineQueryResultRequest
    {
        public string Type => "photo";

        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public int PhotoWidth { get; set; }
        public int PhotoHeight { get; set;}
        public string ThumbUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Caption { get; set; }
        public string MessageText { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool DisableWebPagePreview { get; set; }

        internal override Dictionary<string, object> Parse()
        {
            var data = new Dictionary<string, object>
            {
                { "type", Type },
                { "id", Id },
                { "photo_url", PhotoUrl },
                { "photo_width", PhotoWidth },
                { "photo_height", PhotoHeight },
                { "thumb_url", ThumbUrl },
                { "title", Title },
                { "description", Description },
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
