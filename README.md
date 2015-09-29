# TeleBotDotNet [![Build Status](https://travis-ci.org/Naxiz/TeleBotDotNet.svg?branch=master)](https://travis-ci.org/Naxiz/TeleBotDotNet)

TeleBotDotNet is a Telegram Bot API for the .NET Framework. It is written in C# and is fully object-oriented.

# Example

To send a message:

```c#
var teleBot = new TeleBot("YOUR_API_KEY_HERE", false);

teleBot.SendMessage(new SendMessageRequest
{
    ChatId = updateResponse.Message?.UserChat.Id ?? updateResponse.Message.GroupChat.Id,
    Text = "This is a test.",
    ReplyToMessageId = updateResponse.Message.MessageId
});
```

For an example project, see [Naxiz/TeleBotTicTacToe](https://github.com/Naxiz/TeleBotTicTacToe).
