using _01_Framework.Application;
using _01_Framework.Infrastructure;
using BlogManagament.Infrastructure.EFCore;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _Context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _Context = context;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _Context.Article.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
            }).ToList();
        }

        public EditArticle GetDetails(long id)
        {
            return _Context.Article.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _Context.Article.Include(x => x.Category).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                Slug = x.Slug,
                Title = x.Title,
                CreationDate=x.CreationDate.ToFarsi(),
                Category=x.Category.Name,
                
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (!string.IsNullOrWhiteSpace(searchModel.ShortDescription))
                query = query.Where(x => x.ShortDescription.Contains(searchModel.ShortDescription));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
