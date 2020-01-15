using GraphQL;
using GraphQL.Types;
using MyGraphQL.Infrastructure.GraphQL.Types;
using MyGraphQL.Infrastructure.Models.Models;
using MyGraphQL.Infrastructure.Service.Interfaces;
using System;

namespace MyGraphQL.Infrastructure.GraphQL.QM
{
    [GraphQLMetadata("Mutation")]
    public class ArticleMutation : ObjectGraphType
    {
        public readonly IWriteArticleService _writeArticleService;

        public ArticleMutation(IWriteArticleService writeArticleService)
        {
            _writeArticleService = writeArticleService;
            Field<ArticleType>(
                  "addArticle",
                  arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CreateArticleInputType>>() { Name = "article" }
                  ),
                  resolve: context =>
                  {
                      var article = context.GetArgument<CreateArticleModel>("article");
                      return _writeArticleService.Create(article);
                  });

            RegisterDelete();
        }

        private void RegisterDelete()
        {
            Field<BooleanGraphType>(
                "deleteArticle",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return _writeArticleService.Delete(id);
                });
        }
    }
}
