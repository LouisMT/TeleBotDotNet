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
        private ReplyMarkupTypes _replyMarkupType = ReplyMarkupTypes.None;

        public ReplyMarkupTypes ReplyMarkupType => _replyMarkupType;

        public ReplyKeyboardMarkupRequest ReplyMarkupReplyKeyboardMarkup
        {
            get { return _replyMarkupReplyKeyboardMarkup; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = value;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = null;

                _replyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ReplyKeyboardMarkup;
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

                _replyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ReplyKeyboardHide;
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

                _replyMarkupType = value == null ? ReplyMarkupTypes.None : ReplyMarkupTypes.ForceReply;
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