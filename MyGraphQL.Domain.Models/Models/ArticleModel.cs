using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Infrastructure.Models.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ArticleInfoModel ArticleInfo { get; set; }
    }

}
