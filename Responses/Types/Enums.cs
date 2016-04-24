namespace TeleBotDotNet.Responses.Types
{
    public enum ChatType
    {
        Private,
        Group,
        Channel,
        Supergroup
    }

    public enum MessageEntityType
    {
        Mention,
        Hashtag,
        BotCommand,
        Url,
        Email,
        Bold,
        Italic,
        Code,
        Pre,
        TextLink
    }
}
