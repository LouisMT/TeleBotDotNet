using System.Collections.Generic;

namespace TeleBotDotNet.Responses.Types
{
    public class UserProfilePhotosResponse
    {
        public UserProfilePhotosResponse()
        {
            Photos = new List<PhotoSizeResponse>();
        }

        public int TotalCount { get; private set; }
        public List<PhotoSizeResponse> Photos { get; private set; }

        internal static UserProfilePhotosResponse Parse(Json data)
        {
            if (data == null || !data.Has("total_count") || !data.Has("photos"))
            {
                return null;
            }

            var userProfilePhotosResponse = new UserProfilePhotosResponse
            {
                TotalCount = data.Get<int>("total_count")
            };

            foreach (var photo in data.GetJsonList("photo"))
            {
                userProfilePhotosResponse.Photos.Add(PhotoSizeResponse.Parse(photo));
            }

            return userProfilePhotosResponse;
        }
    }
}