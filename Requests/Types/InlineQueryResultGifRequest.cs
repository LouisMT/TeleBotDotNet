using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Types
{
    public class InlineQueryResultGifRequest : BaseInlineQueryResultRequest, IInlineQueryResultRequest
    {
        public string Type => "gif";

        public string Id { get; set; }
        public string GifUrl { get; set; }
        public int GifWidth { get; set; }
        public int GifHeight { get; set; }
        public string ThumbUrl { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string MessageText { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool DisableWebPagePreview { get; set; }

        internal override dynamic Parse()
        {
            return new
            {
                type = Type,
                id = Id,
                gif_url = GifUrl,
                gif_width = GifWidth,
                gif_height = GifHeight,
                thumb_url = ThumbUrl,
                title = Title,
                caption = Caption,
                message_text = MessageText,
                parse_mode = ParseMode.GetValue(),
                disable_web_page_preview = DisableWebPagePreview
            };
        }
    }
}
