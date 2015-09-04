namespace TeleBotDotNet.Responses.Types
{
    public class UserResponse
    {
        /// <summary>
        ///     Unique identifier for this user or bot
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     User's or bot's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Optional. User's or bot's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Optional. User's or bot's username
        /// </summary>
        public string UserName { get; set; }

        internal static UserResponse Parse(Json data)
        {
            if (data == null || !data.Has("id") || !data.Has("first_name"))
            {
                return null;
            }

            return new UserResponse
            {
                Id = data.Get<int>("id"),
                FirstName = data.Get<string>("first_name"),
                LastName = data.Get<string>("last_name"),
                UserName = data.Get<string>("username")
            };
        }
    }
}