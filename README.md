# TeleBotDotNet [![Build Status](https://travis-ci.org/LouisMT/TeleBotDotNet.svg?branch=master)](https://travis-ci.org/LouisMT/TeleBotDotNet)

TeleBotDotNet is a Telegram Bot API for the .NET Framework. It is written in C# and is fully object-oriented.

## Example

To send a message:

```c#
var teleBot = new TeleBot("YOUR_API_KEY_HERE", false);

teleBot.SendMessage(new SendMessageRequest
{
    ChatId = updateResponse.Message?.Chat?.Id,
    Text = "This is a test.",
    ReplyToMessageId = updateResponse.Message.MessageId
});
```

For an example project, see [LouisMT/TeleBotTicTacToe](https://github.com/LouisMT/TeleBotTicTacToe).

## Documentation

The documentation is not included in the library. Please see the [official documentation](https://core.telegram.org/bots/api) (for example `getMe` in the documentation becomes `GetMe` in the library).

## API extensions

TeleBotDotNet has some API extensions. These extensions are methods which are not part of the official API but can be useful.

To use these, please add the following using statement:

    using TeleBotDotNet.Extensions;

Currently, the following methods are available:

* `DownloadFile(GetFileResponse)`

  Download a file as a byte array using a `GetFileResponse`
* `DownloadFileAsync(GetFileResponse)`

  Download a file as a byte array async using a `GetFileResponse`

## NuGet

To use this library in your project, you can use NuGet:

    Install-Package TeleBotDotNet

More information on [NuGet](https://www.nuget.org/packages/TeleBotDotNet).

## Contributing

Contributions are always welcome!

If you want to be sure that your contribution will be merged, please open an issue to discuss your addition first.
