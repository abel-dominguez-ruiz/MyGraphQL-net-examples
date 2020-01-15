using GraphQL.Types;
using MyGraphQL.Infrastructure.GraphQL.QM;

namespace MyGraphQL.Infrastructure.GraphQL
{
    public class ArticleSchema : Schema
    {
        public ArticleSchema(ArticleQuery query, ArticleMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }

    }
}
