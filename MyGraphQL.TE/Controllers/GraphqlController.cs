using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using MyGraphQL.Infrastructure.GraphQL;

namespace MyGraphQL.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        private readonly ArticleSchema _articleSchema;

        public GraphqlController(
            ArticleSchema articleSchema)
        {
            _articleSchema = articleSchema;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _articleSchema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}

