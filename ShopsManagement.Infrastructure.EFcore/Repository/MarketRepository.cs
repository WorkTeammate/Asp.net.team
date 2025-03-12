using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Application.Contracts.Shops;
using ShopsManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Repository
{
    public class MarketRepository : RepositoryBase<long, Markets>, IMarketsRepository
    {
        private readonly ShopsContext _context;

        public MarketRepository(ShopsContext context) : base(context)
        {
            _context = context;
        }


        public EditMarkets GetDetails(long id)
        {
            return _context.Markets
                .Select(x => new EditMarkets
            {
                Id = x.Id,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CategoryId = x.CategoryId,
                Description = x.Description,
                EnglishName = x.EnglishName,
                PersianName = x.PersianName,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                KeyWords=x.KewWords,
                

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MarketViewModel> GetMarkets()
        {
            return _context.Markets.Select(x=>new MarketViewModel
            {

                Id = x.Id,
                Longitude=x.Longitude,
                Latitude=x.Latitude,
                CategoryId = x.CategoryId,
                Description = x.Description,
                EnglishName = x.EnglishName,
                PersianName = x.PersianName,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                IsRemoved = x.IsRemoved,
                


            }).ToList();
        }

        public string GetSlugById(long id)
        {
            return _context.MarketCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<MarketViewModel> Search(MarketSearchModel searchModel)
        {
            var query = _context.Markets.Include(x=>x.MarketCategory).Select(x => new MarketViewModel
            {
                Id = x.Id,
                Longitude = x.Longitude,
                Latitude = x.Latitude,
                CategoryId = x.CategoryId,
                Description = x.Description,
                EnglishName = x.EnglishName,
                PersianName = x.PersianName,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                IsRemoved=x.IsRemoved,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                MarketCategory=x.MarketCategory.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                
            });

            if (!string.IsNullOrWhiteSpace(searchModel.PersianName))
                query = query.Where(x => x.PersianName.Contains(searchModel.PersianName));

            if (!string.IsNullOrWhiteSpace(searchModel.EnglishName))
                query = query.Where(x => x.EnglishName.Contains(searchModel.EnglishName));

            if (!string.IsNullOrWhiteSpace(searchModel.ShortDescription))
                query = query.Where(x => x.ShortDescription.Contains(searchModel.ShortDescription));

            if (searchModel.CategoryId !=0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();


        }
    }
}
