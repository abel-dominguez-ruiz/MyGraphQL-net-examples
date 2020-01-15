

using MyGraphQL.Domain.Entity.Interfaces;
using System.Collections.Generic;

namespace MyGraphQL.Domain.Entity.Entities
{
    public class Article : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 0.0;

        public List<ArticleInfo> ArticleInfo { get; set; }

        public List<ShoppingCartArticle> ShoppingCartArticles { get; set; }
    }
}
