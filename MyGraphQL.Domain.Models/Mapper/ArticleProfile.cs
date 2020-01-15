using AutoMapper;
using MyGraphQL.Domain.Entity.Entities;
using MyGraphQL.Infrastructure.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Infrastructure.Models.Mapper
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<Article, CreateArticleModel>().ReverseMap();

        }
    }
}
