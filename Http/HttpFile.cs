namespace TeleBotDotNet.Http
{
    internal class HttpFile
    {
        internal string Key { get; set; }
        internal string FileName { get; set; }
        internal string ContentType { get; set; }
        internal byte[] File { get; set; }
    }
}