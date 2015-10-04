using System.Net;
using System.Threading.Tasks;
using TeleBotDotNet.Responses.Methods;

namespace TeleBotDotNet.Extensions
{
    public static class TeleBotExtensions
    {
        /// <summary>
        /// Download a file.
        /// </summary>
        public static byte[] DownloadFile(this GetFileResponse getFileResponse, TeleBot bot)
        {
            bot.Log.Info(nameof(DownloadFile));

            if (string.IsNullOrEmpty(getFileResponse?.Result?.FilePath))
            {
                return null;
            }

            using (var client = new WebClient())
            {
                try
                {
                    return client.DownloadData($"{TeleBot.ApiUrl}/file/bot{bot.ApiToken}/{getFileResponse.Result.FilePath}");
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Download a file async.
        /// </summary>
        public static async Task<byte[]> DownloadFileAsync(this GetFileResponse getFileResponse, TeleBot bot)
        {
            bot.Log.Info(nameof(DownloadFileAsync));

            if (string.IsNullOrEmpty(getFileResponse?.Result?.FilePath))
            {
                return null;
            }

            using (var client = new WebClient())
            {
                try
                {
                    return await client.DownloadDataTaskAsync($"{TeleBot.ApiUrl}/file/bot{bot.ApiToken}/{getFileResponse.Result.FilePath}");

                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
