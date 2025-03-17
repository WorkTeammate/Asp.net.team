using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _blogContext.ArticleCategory.Select(x => new ArticleCategoryViewModel
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _blogContext.ArticleCategory.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                IsDeleted = x.IsDeleted,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _blogContext.ArticleCategory.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                IsDeleted = x.IsDeleted,
                KeyWords = x.KeyWords,
                MeatDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                CreationDate=x.CreationDate.ToFarsi(),
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.Id > 0)
                query = query.Where(x => x.Id == searchModel.Id);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
