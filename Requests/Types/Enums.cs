namespace TeleBotDotNet.Requests.Types
{
    public enum ParseMode
    {
        Normal,
        Markdown,
        Html
    }

    public enum ChatAction
    {
        Typing,
        UploadPhoto,
        RecordVideo,
        UploadVideo,
        RecordAudio,
        UploadAudio,
        UploadDocument,
        FindLocation
    }

    public enum InputFileType
    {
        String,
        File
    }

    public enum ReplyMarkupType
    {
        None,
        ReplyKeyboardMarkup,
        ReplyKeyboardHide,
        ForceReply
    }
}
