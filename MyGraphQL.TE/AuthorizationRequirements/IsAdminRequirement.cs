using Microsoft.AspNetCore.Authorization;
using MyGraphQL.Api.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MyGraphQL.Api.AuthorizationRequirements
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
        public int test = 1;
    }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly ILogger<IsAdminHandler> _logger;
        public IsAdminHandler(ILogger<IsAdminHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsAdminRequirement requirement)
        {
            var userInSession = context.User.ToUserToken();

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
