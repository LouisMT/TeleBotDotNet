using System.Collections.Generic;

namespace TeleBotDotNet.Responses.Types
{
    public class UserProfilePhotosResponse
    {
        public UserProfilePhotosResponse()
        {
            Photos = new List<PhotoSizeResponse>();
        }

        public int TotalCount { get; set; }
        public List<PhotoSizeResponse> Photos { get; set; } 

        internal static UserProfilePhotosResponse Parse(dynamic data)
        {
            if (data == null || data.total_count == null || data.photos == null)
            {
                return null;
            }

            var userProfilePhotosResponse = new UserProfilePhotosResponse
            {
                TotalCount = data.total_count
            };

            foreach (var photo in data.photos)
            {
                userProfilePhotosResponse.Photos.Add(PhotoSizeResponse.Parse(photo));
            }

            return userProfilePhotosResponse;
        }
    }
}