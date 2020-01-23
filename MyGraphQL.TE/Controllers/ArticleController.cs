using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyGraphQL.Infrastructure.Models.Models;
using MyGraphQL.Infrastructure.Service;
using MyGraphQL.Infrastructure.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGraphQL.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {

        private readonly IReadArticleService _readArticleService;
        private readonly IWriteArticleService _writeArticleService;

        public ArticleController(
            IReadArticleService readArticleService,
            IWriteArticleService writeArticleService)
        {
            _readArticleService = readArticleService;
            _writeArticleService = writeArticleService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleModel>> GetAll()
        {
            var result = await _readArticleService.GetAll();
            return result;
        }

        [Authorize("IsAdmin")]
        [HttpGet("v2")]
        public async Task<IEnumerable<ArticleModel>> GetAllv2()
        {
            var result = await _readArticleService.GetAll();
            return result;
        }


        [HttpPost]
        public async Task<ArticleModel> CreateArticle(CreateArticleModel model)
        {
            var result = await _writeArticleService.Create(model);
            return result;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            return null;
        }
    }
}
