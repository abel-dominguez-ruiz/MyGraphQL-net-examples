using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyGraphQL.Api.AuthorizationRequirements
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
    }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement, AuthorizationFilterContext>
    {
        private readonly ILogger<IsAdminHandler> _logger;
        public IsAdminHandler(ILogger<IsAdminHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsAdminRequirement requirement,
            AuthorizationFilterContext resource)
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
