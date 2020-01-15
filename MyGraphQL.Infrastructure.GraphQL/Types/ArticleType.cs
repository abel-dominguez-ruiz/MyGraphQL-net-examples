using GraphQL.Types;
using MyGraphQL.Domain.Entity.Entities;
using MyGraphQL.Infrastructure.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Infrastructure.GraphQL.Types
{
    public class ArticleType : ObjectGraphType<ArticleModel>
    {
        public ArticleType()
        {
            Field(article => article.Id);
            Field(article => article.Name);
            Field(article => article.Price);
            Field(article => article.Description);
        }
    }
}
