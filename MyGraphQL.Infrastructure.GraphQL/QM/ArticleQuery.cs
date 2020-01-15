
using GraphQL.Types;
using MyGraphQL.Infrastructure.GraphQL.Types;
using MyGraphQL.Infrastructure.Service;

namespace MyGraphQL.Infrastructure.GraphQL.QM
{

    public class ArticleQuery : ObjectGraphType
    {
        public readonly IReadArticleService _readArticleService;

        public ArticleQuery(IReadArticleService readArticleService)
        {
            _readArticleService = readArticleService;

            Field<ListGraphType<ArticleType>>(
                "articles",
                resolve: context => readArticleService.GetAll());


            Field<ArticleType>(
                "article",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                  {
                      var id = context.GetArgument<int>("id");
                      return readArticleService.GetOne(id);
                  });
        }

    }
}
