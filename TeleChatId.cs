namespace TeleBotDotNet
{
    public class TeleChatId
    {
        private readonly string _chatId;

        public TeleChatId(int chatId)
        {
            _chatId = chatId.ToString();
        }

        public TeleChatId(string chatId)
        {
            _chatId = chatId;
        }

        public override string ToString()
        {
            return _chatId;
        }
    }
}
