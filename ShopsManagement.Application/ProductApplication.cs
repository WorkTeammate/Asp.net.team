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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            var FileProductPath = _fileUploader.Upload(command.FileProduct, pathFileProduct);

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


            product.Edit(command.Name, command.ShortDescription, command.Description,
                 command.PictureAlt, command.PictureTitle, slug, command.Keywords
                , command.MetaDescription, command.CategoryId ,command.AccountId);

            _productRepository.SaveChanges();
            return operation.Successful();
        }
        public OperationResult Delete(long id)
        {
            var opration = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            product.Remove();
            _productRepository.SaveChanges();
            return opration.Successful();
        }
        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            product.Restore();
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



            var LastPicture = $"Product/{Product.Slug}/Files";

            if (!string.IsNullOrWhiteSpace(Product.FileProducts))
                System.IO.File.Delete(LastPicture);

            var FileProductPath = _fileUploader.Upload(command.FileProduct, LastPicture);

            Product.EditFileProduct(FileProductPath);
            _productRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult Published(long id)
        {
            var opration = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            product.Published();
            _productRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult RejectProduct(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if(product==null)
                operation.Failed(ApplicationMessages.RecordNotFound);


            var pathFileProduct = $"wwwroot/AdminTheme/UploadPicture/{product.FileProducts}";
            System.IO.File.Delete(pathFileProduct);

            var profile = $"wwwroot/AdminTheme/UploadPicture/{product.Picture}";
            System.IO.File.Delete(profile);

            _productRepository.Remove(product);
            _productRepository.SaveChanges();
            return operation.Successful();

        }

        public OperationResult EditPictureProduct(EditPictureProduct command)
        {
            var opration = new OperationResult();

            var Product = _productRepository.Get(command.Id);
            if (Product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);


            var LastPicture = $"wwwroot/AdminTheme/UploadPicture/{Product.Picture}";
            if(!string.IsNullOrWhiteSpace(Product.Picture))
                  System.IO.File.Delete(LastPicture);

            var pathFileProduct = $"Product/{Product.Slug}/";
            var FileProductPath = _fileUploader.Upload(command.PictureProduct, pathFileProduct);

            Product.EditPictureProduct(FileProductPath);
            _productRepository.SaveChanges();
            return opration.Successful();
        }
    }
}
