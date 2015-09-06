using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class LocationResponse
    {
        public float Longitude { get; private set; }
        public float Latitude { get; private set; }

        internal static LocationResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("longitude") || !data.Has("latitude"))
            {
                return null;
            }

            return new LocationResponse
            {
                Longitude = data.Get<float>("longitude"),
                Latitude = data.Get<float>("latitude")
            };
        }
    }
}