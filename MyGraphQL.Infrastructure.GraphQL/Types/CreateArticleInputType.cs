using GraphQL.Types;
using MyGraphQL.Infrastructure.Models.Models;
namespace MyGraphQL.Infrastructure.GraphQL.Types
{
    public class CreateArticleInputType : InputObjectGraphType
    {
        public CreateArticleInputType()
        {
            Name = nameof(CreateArticleInputType);
            Field<NonNullGraphType<StringGraphType>>(nameof(CreateArticleModel.Name).ToLowerInvariant());
            Field<NonNullGraphType<FloatGraphType>>(nameof(CreateArticleModel.Price).ToLowerInvariant());
            Field<NonNullGraphType<StringGraphType>>(nameof(CreateArticleModel.Description).ToLowerInvariant());
        }
    }
}
