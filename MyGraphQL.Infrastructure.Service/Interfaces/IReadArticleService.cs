using MyGraphQL.Infrastructure.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphQL.Infrastructure.Service
{
    public interface IReadArticleService
    {

        Task<IEnumerable<ArticleModel>> GetAll();

        Task<ArticleModel> GetOne(int id);

    }
}
