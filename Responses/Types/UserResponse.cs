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

        internal static UserResponse Parse(dynamic data)
        {
            if (data == null || data.id == null || data.first_name == null)
            {
                return null;
            }

            return new UserResponse
            {
                Id = data.id,
                FirstName = data.first_name,
                LastName = data.last_name,
                UserName = data.username
            };
        }
    }
}