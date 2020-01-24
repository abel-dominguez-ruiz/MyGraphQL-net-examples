using System;

namespace MyGraphQL.Api.Models
{
    public class UserToken
    {
        public string IdentityId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
