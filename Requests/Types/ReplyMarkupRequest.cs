using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ReplyMarkupRequest : BaseTypeRequest
    {
        public enum ReplyMarkupTypes
        {
            None,
            ReplyKeyboardMarkup,
            ReplyKeyboardHide,
            ForceReply
        }

        private ForceReplyRequest _replyMarkupForceReply;
        private ReplyKeyboardHideRequest _replyMarkupReplyKeyboardHide;
        private ReplyKeyboardMarkupRequest _replyMarkupReplyKeyboardMarkup;

        public ReplyMarkupTypes ReplyMarkupType { get; private set; } = ReplyMarkupTypes.None;

        public ReplyKeyboardMarkupRequest ReplyMarkupReplyKeyboardMarkup
        {
            get { return _replyMarkupReplyKeyboardMarkup; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = value;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = null;

                ReplyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ReplyKeyboardMarkup;
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

                ReplyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ReplyKeyboardHide;
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

                ReplyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ForceReply;
            }
        }

        internal override void Parse(HttpData httpData, string key)
        {
            switch (ReplyMarkupType)
            {
                case ReplyMarkupTypes.ReplyKeyboardMarkup:
                    ReplyMarkupReplyKeyboardMarkup.Parse(httpData, key);
                    break;

                case ReplyMarkupTypes.ReplyKeyboardHide:
                    ReplyMarkupReplyKeyboardHide.Parse(httpData, key);
                    break;

                case ReplyMarkupTypes.ForceReply:
                    ReplyMarkupForceReply.Parse(httpData, key);
                    break;
            }
        }
    }
}