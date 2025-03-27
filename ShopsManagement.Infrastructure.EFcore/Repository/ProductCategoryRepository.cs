using _01_Framework.Application;
using _01_Framework.Infrastructure;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopsContext _context;

        public ProductCategoryRepository(ShopsContext context) : base(context) 
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategory.Select(x => new EditProductCategory
            {
                Id = x.Id,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ShortDescription=x.ShortDescription,
                Slug=x.Slug,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategory.Select(x=>new ProductCategoryViewModel
            {
                Id =x.Id,
                Name = x.Name,
            }).ToList();
        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategory.Select(x=> new {x.Id,x.Slug}).FirstOrDefault(x=>x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategory.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                IsDeleted = x.IsDeleted,
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.ShortDescription))
                query = query.Where(x => x.ShortDescription.Contains(searchModel.ShortDescription));

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
