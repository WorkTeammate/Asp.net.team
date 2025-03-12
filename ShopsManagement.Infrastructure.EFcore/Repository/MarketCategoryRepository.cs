using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopsManagement.Application.Contracts.MarketCategories;
using ShopsManagement.Domain.MarketCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Repository
{
    public class MarketCategoryRepository : RepositoryBase<long, MarketCategory>, IMarketCategoryRepository
    {
        private readonly ShopsContext _context;

        public MarketCategoryRepository(ShopsContext context):base(context) 
        {
            _context = context;
        }
        public EditMarketCategory GetDetails(long id)
        {
            return _context.MarketCategories.Select(x => new EditMarketCategory
            {
                 Id = x.Id,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                 Picture=x.Picture,
                 PictureAlt=x.PictureAlt,
                 PictureTitle =x.PictureTitle,
                 Slug=x.Slug,
                 
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MarketCategoryViewModel> GetMarketCategories()
        {
            return _context.MarketCategories.Select(x => new MarketCategoryViewModel
            {
                Slug = x.Slug,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
            }).ToList();
        }

        public List<MarketCategoryViewModel> Search(MarketCategorySearchModel searchModel)
        {
            var query =  _context.MarketCategories.Select(x => new MarketCategoryViewModel
            {
                Slug = x.Slug,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Description))
                query = query.Where(x => x.Description.Contains(searchModel.Description));

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
