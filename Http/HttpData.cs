namespace TeleBotDotNet.Http
{
    internal class HttpData
    {
        internal HttpData()
        {
            Parameters = new HttpParameterList();
            Files = new HttpFileList();
        }

        internal HttpParameterList Parameters { get; set; }
        internal HttpFileList Files { get; set; }
    }
}