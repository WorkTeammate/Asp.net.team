using _01_Framework.Application;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;

        public ProductCategoryApplication(IProductCategoryRepository repository
            , IFileUploader fileUploader, IAuthHelper authHelper)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateProductCategory command)
        {
           var operation = new OperationResult();
            if (_repository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var picturePath = $"ProductCategory/{command.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, picturePath);

            var account = _authHelper.CurrentAccountInfo();
            if(account.Id < 0)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var productCategpry = new ProductCategory(command.Name, command.ShortDescription
                , pictureName, command.PictureAlt, command.PictureTitle,
                command.KeyWords, command.MetaDescription, slug,account.Id);
            
            _repository.Create(productCategpry);
            _repository.SaveChanges();
            return operation.Successful();

        }

        public OperationResult Delete(long id)
        {
            var Operation = new OperationResult();
            var ProductCategory = _repository.Get(id);
            if (ProductCategory == null)
                return Operation.Failed(ApplicationMessages.RecordNotFound);

            ProductCategory.Delete();
            _repository.SaveChanges();
            return Operation.Successful();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _repository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var picturePath = $"ProductCategory/{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            productCategory.Edit(command.Name, command.ShortDescription, fileName,
                command.PictureAlt, command.PictureTitle, command.KeyWords,
                command.MetaDescription, slug);

            _repository.SaveChanges();
            return operation.Successful();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
          return _repository.GetProductCategories();
        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();
            var ProductCategory = _repository.Get(id);
            if (ProductCategory == null)
                return Operation.Failed(ApplicationMessages.RecordNotFound);

            ProductCategory.Restore();
            _repository.SaveChanges();
            return Operation.Successful();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
          return _repository.Search(searchModel);
        }
    }
}
