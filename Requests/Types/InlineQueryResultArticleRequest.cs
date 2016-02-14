using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Types
{
    public class InlineQueryResultArticleRequest : BaseInlineQueryResultRequest, IInlineQueryResultRequest
    {
        public string Type => "article";

        public string Id { get; set; }
        public string Title { get; set; }
        public string MessageText { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool DisableWebPagePreview { get; set; }
        public string Url { get; set; }
        public bool HideUrl { get; set; }
        public string Description { get; set; }
        public string ThumbUrl { get; set; }
        public int ThumbWidth { get; set; }
        public int ThumbHeight { get; set; }

        internal override dynamic Parse()
        {
            return new
            {
                type = Type,
                id = Id,
                title = Title,
                message_text = MessageText,
                parse_mode = ParseMode.GetValue(),
                disable_web_page_preview = DisableWebPagePreview,
                url = Url,
                hide_url = HideUrl,
                description = Description,
                thumb_url = ThumbUrl,
                thumb_width = ThumbWidth,
                thumb_height = ThumbHeight
            };
        }
    }
}
