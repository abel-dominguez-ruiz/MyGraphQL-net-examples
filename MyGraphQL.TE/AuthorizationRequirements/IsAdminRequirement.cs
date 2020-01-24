using Microsoft.AspNetCore.Authorization;
using MyGraphQL.Api.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MyGraphQL.Api.AuthorizationRequirements
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
        public int test = 1;
    }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly ILogger<IsAdminHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsAdminHandler(ILogger<IsAdminHandler> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsAdminRequirement requirement)
        {

            if (context.User.Claims.Count() == 0)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var userInSession = context.User.ToUserToken();
            _httpContextAccessor.HttpContext.Items["user"] = userInSession;
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
