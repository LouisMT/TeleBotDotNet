using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ReplyMarkupRequest : BaseTypeRequest
    {
        private ForceReplyRequest _replyMarkupForceReply;
        private ReplyKeyboardHideRequest _replyMarkupReplyKeyboardHide;
        private ReplyKeyboardMarkupRequest _replyMarkupReplyKeyboardMarkup;

        public ReplyMarkupType ReplyMarkupType { get; private set; } = ReplyMarkupType.None;

        public ReplyKeyboardMarkupRequest ReplyMarkupReplyKeyboardMarkup
        {
            get { return _replyMarkupReplyKeyboardMarkup; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = value;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = null;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ReplyKeyboardMarkup;
            }
        }

        public ReplyKeyboardHideRequest ReplyMarkupReplyKeyboardHide
        {
            get { return _replyMarkupReplyKeyboardHide; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = null;
                _replyMarkupReplyKeyboardHide = value;
                _replyMarkupForceReply = null;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ReplyKeyboardHide;
            }
        }

        public ForceReplyRequest ReplyMarkupForceReply
        {
            get { return _replyMarkupForceReply; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = null;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = value;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ForceReply;
            }
        }

        internal override void Parse(HttpData httpData, string key)
        {
            switch (ReplyMarkupType)
            {
                case ReplyMarkupType.ReplyKeyboardMarkup:
                    ReplyMarkupReplyKeyboardMarkup.Parse(httpData, key);
                    break;

                case ReplyMarkupType.ReplyKeyboardHide:
                    ReplyMarkupReplyKeyboardHide.Parse(httpData, key);
                    break;

                case ReplyMarkupType.ForceReply:
                    ReplyMarkupForceReply.Parse(httpData, key);
                    break;
            }
        }
    }
}