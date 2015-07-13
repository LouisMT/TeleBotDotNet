namespace TeleBotDotNet.Responses.Methods.Bases
{
    public class BaseMethodResponse
    {
        public bool Ok { get; set; }
        public int? ErrorCode { get; set; }
        public string Description { get; set; }
    }
}