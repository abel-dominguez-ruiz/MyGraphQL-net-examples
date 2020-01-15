using MyGraphQL.Domain.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGraphQL.Domain.Entity.Entities
{
    public class ShoppingCart : IEntity<int>
    {
        public int Id { get; set; }

        public double TotalPrice
        {
            get
            {
               return ShoppingCartArticles != null ? ShoppingCartArticles.Sum(x => x.Article.Price * x.Quantity) : 0.0;
            }
        }

        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public ICollection<ShoppingCartArticle> ShoppingCartArticles { get; set; } = new HashSet<ShoppingCartArticle>();
    }
}
