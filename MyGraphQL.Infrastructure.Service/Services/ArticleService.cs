using MyGraphQL.Domain.EF;
using MyGraphQL.Domain.Entity.Entities;
using MyGraphQL.Infrastructure.Models.Mapper;
using MyGraphQL.Infrastructure.Models.Models;
using MyGraphQL.Infrastructure.Service.Interfaces;
using Pc.Commons.Share.Mapper;
using Pc.Commons.Share.Mapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQL.Infrastructure.Service.Services
{
    public class ArticleService : IReadArticleService, IWriteArticleService
    {
        private readonly ArticlesDbContext _articlesDbContext;
        private readonly IToModelMapper<Article, ArticleModel> _conversor;

        public ArticleService(ArticlesDbContext articlesDbContext)
        {
            _articlesDbContext = articlesDbContext;
            _conversor = new MapperBuilder()
               .AddProfile<ArticleProfile>()
               .BuildTwoWayMapper<Article, ArticleModel>(nameof(ArticleService));
        }

        public async Task<IEnumerable<ArticleModel>> GetAll()
        {
            var articles = _articlesDbContext.Articles.ToList();
            return await Task.FromResult(_conversor.MapTo<Article, ArticleModel>(articles.AsEnumerable()));
        }

        public async Task<ArticleModel> GetOne(int id)
        {
            var articles = _articlesDbContext.Articles.FirstOrDefault(art => art.Id == id);
            return await Task.FromResult(_conversor.MapTo<Article, ArticleModel>(articles));
        }


        public async Task<ArticleModel> Create(CreateArticleModel model)
        {
            var entityToSave = _conversor.MapTo<CreateArticleModel, Article>(model);
            _articlesDbContext.Articles.Add(entityToSave);
            await _articlesDbContext.SaveChangesAsync();

            return _conversor.MapTo<Article, ArticleModel>(entityToSave);
        }

        public async Task<bool> Delete(int articleId)
        {
            var result = true;
            try
            {
                var articleFound = _articlesDbContext.Articles.FirstOrDefault(art => art.Id == articleId);
                _articlesDbContext.Remove(articleFound);
                await _articlesDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
