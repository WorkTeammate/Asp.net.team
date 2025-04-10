using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using Market.ShopsManagement.Domain.ProductsAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Domain.ProductsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Repository
{
    public class ProductRepository : RepositoryBase<long, Products>, IProductRepository
    {
        private readonly ShopsContext _context;
        private readonly AccountContext _accountContext;
        private readonly IAuthHelper _authHelper;

        public ProductRepository(ShopsContext context
            , AccountContext accountContext, IAuthHelper authHelper) : base(context)
        {
            _context = context;
            _accountContext = accountContext;
            _authHelper = authHelper;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                AccountId=x.AccountId,

            }).OrderByDescending(x => x.Id).FirstOrDefault(x => x.Id == id);


        }

        public List<ProductViewModel> GetProducts()
        {
            var account = _authHelper.CurrentAccountInfo();
            if(account.Id < 0)
                return new List<ProductViewModel>();

            if(account.RoleId == Roles.AdminLong)
            {
                return _context.Products.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
            else
            {
                return _context.Products.Where(x => x.AccountId == account.Id).Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }

        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategory.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public void Remove(Products product)
        {
           _context.Products.Remove(product);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var account = _accountContext.Account.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                IsDeleted = x.IsDeleted,
                Category = x.Category.Name,
                AccountId = x.AccountId,
                FileProduct = x.FileProducts,
                IsPublished = x.IsPublished,
            });


            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));


            if (!string.IsNullOrWhiteSpace(searchModel.ShortDescription))
                query = query.Where(x => x.ShortDescription.Contains(searchModel.ShortDescription));


            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            var Products = query.OrderByDescending(x => x.Id).ToList();
            Products.ForEach(product =>
            {
                product.Accounts = account.FirstOrDefault(x => x.Id == product.AccountId)?.Username;
            });


            return Products;

        }
    }
}
