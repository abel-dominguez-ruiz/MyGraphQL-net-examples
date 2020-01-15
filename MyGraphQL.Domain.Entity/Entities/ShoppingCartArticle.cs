using MyGraphQL.Domain.Entity.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQL.Domain.Entity.Entities
{
    public class ShoppingCartArticle : IEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ArticleId { get; set; }
        public int ShoppingCartId { get; set; }

        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
        public Article Article { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
