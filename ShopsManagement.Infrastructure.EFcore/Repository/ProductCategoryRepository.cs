using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
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
        private readonly IAuthHelper _authHelper;
        private readonly AccountContext _accountContext;

        public ProductCategoryRepository(ShopsContext context
            , IAuthHelper authHelper, AccountContext accountContext) : base(context)
        {
            _context = context;
            _authHelper = authHelper;
            _accountContext = accountContext;
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
            var account = _authHelper.CurrentAccountInfo();
            if (account.Id < 0)
                return new List<ProductCategoryViewModel>();

            if (account.RoleId == Roles.AdminLong)
            {
                return _context.ProductCategory.Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
            else
            {
                return _context.ProductCategory.Where(x => x.AccountId == account.Id).Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }

        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategory.Select(x=> new {x.Id,x.Slug}).FirstOrDefault(x=>x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var account = _accountContext.Account.Select(x => new { x.Id, x.Username }).ToList();
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

            var ProductCategory = query.OrderByDescending(x => x.Id).ToList();
            ProductCategory.ForEach(ProductCategory =>
            {
                ProductCategory.Accounts = account.FirstOrDefault(x => x.Id == ProductCategory.AccountId)?.Username;
            });
            return ProductCategory;
        }
    }
}
