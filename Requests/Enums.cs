namespace TeleBotDotNet.Requests
{
    public enum ParseMode
    {
        Normal,
        Markdown
    }

    public enum Action
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
