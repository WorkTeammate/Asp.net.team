using _01_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using Market.ShopsManagement.Domain.ProductsAgg;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Domain.ProductsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository
            , IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _productRepository = productRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
        }

        public OperationResult CreateProduct(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name && x.AccountId == command.AccountId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var categorySlug = _productRepository.GetSlugById(command.CategoryId);

            var path = $"Product/{slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var pathFileProduct = $"Product/{slug}/Files";
            var FileProductPath = _fileUploader.Upload(command.Picture, pathFileProduct);

            var product = new Products(command.Name, command.ShortDescription, command.Description,
                 picturePath, command.PictureAlt, command.PictureTitle, slug, command.Keywords,
                 command.MetaDescription, command.CategoryId,command.AccountId , FileProductPath);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Successful();

        }
        public OperationResult EditProduct(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id && x.AccountId ==command.AccountId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"Product/{slug}";

            var picturePath = _fileUploader.Upload(command.Picture, path);

            product.Edit(command.Name, command.ShortDescription, command.Description,
                picturePath, command.PictureAlt, command.PictureTitle, slug, command.Keywords
                , command.MetaDescription, command.CategoryId ,command.AccountId);

            _productRepository.SaveChanges();
            return operation.Successful();
        }
        public OperationResult Delete(long id)
        {
            var opration = new OperationResult();

            var market = _productRepository.Get(id);
            if (market == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            market.Remove();
            _productRepository.SaveChanges();
            return opration.Successful();
        }
        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();

            var market = _productRepository.Get(id);
            if (market == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            market.Restore();
            _productRepository.SaveChanges();
            return opration.Successful();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public OperationResult EditFileProduct(EditFileProduct command)
        {
            var opration = new OperationResult();

            var Product = _productRepository.Get(command.Id);
            if (Product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            var pathFileProduct = $"Product/{Product.Slug}/Files";
            var FileProductPath = _fileUploader.Upload(command.FileProduct, pathFileProduct);

            Product.EditFileProduct(FileProductPath);
            _productRepository.SaveChanges();
            return opration.Successful();
        }
    }
}
