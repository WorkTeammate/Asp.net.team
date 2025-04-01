using _01_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Domain.ProductAgg;
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

        public ProductApplication(IProductRepository productRepository, IAuthHelper authHelper)
        {
            _productRepository = productRepository;
            _authHelper = authHelper;
        }

        public OperationResult CreateProduct(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var product = new Product(command.Name, command.ShortDescription, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords,
                command.MetaDescription,command.CategoryId);
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

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            product.Edit(command.Name, command.ShortDescription, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords
                , command.MetaDescription,command.CategoryId);

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
    }
}
