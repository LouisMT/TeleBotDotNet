namespace TeleBotDotNet.Responses.Types
{
    public class LocationResponse
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        internal static LocationResponse Parse(Json data)
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