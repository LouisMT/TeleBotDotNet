namespace TeleBotDotNet.Responses.Methods.Bases
{
    public class BaseMethodResponse
    {
        public bool Ok { get; protected set; }
        public int? ErrorCode { get; protected set; }
        public string Description { get; protected set; }

        public override string ToString()
        {
            return $"is OK: {Ok} ErrorCode: {ErrorCode} Description: {Description}";
        }
    }
}