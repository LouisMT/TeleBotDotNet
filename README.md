# TeleBotDotNet

TeleBotDotNet is a Telegram Bot API for the .NET Framework. It is written in C# and fully object-oriented.

# Example

To send a message:

```c#
var teleBot = new TeleBot("YOUR_API_KEY_HERE", false);

teleBot.SendMessage(new SendMessageRequest
{
    ChatId = updateResponse.Message.UserChat == null ?
        updateResponse.Message.GroupChat.Id : updateResponse.Message.UserChat.Id,
    Text = "This is a test.",
    ReplyToMessageId = updateResponse.Message.MessageId
});
```

For more see [Naxiz/TeleBotDotNetExamples](https://github.com/Naxiz/TeleBotDotNetExamples).
