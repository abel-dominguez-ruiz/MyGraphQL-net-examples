using MyGraphQL.Infrastructure.Models.Models;
using System.Threading.Tasks;

namespace MyGraphQL.Infrastructure.Service.Interfaces
{
    public interface IWriteArticleService
    {
        Task<ArticleModel> Create(CreateArticleModel model);

        Task<bool> Delete(int id);
    }
}
