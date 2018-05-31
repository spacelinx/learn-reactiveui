using System;

namespace Learn.Core.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserSocialId { get; set; }

        public string Token { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public bool LoggedInWithMicrosoftAccount { get; set; }
        public bool LoggedInWithGoogleAccount { get; set; }
        public bool LoggedInWithFacebookAccount { get; set; }
    }
}
