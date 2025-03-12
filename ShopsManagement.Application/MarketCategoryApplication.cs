using _0_Framework.Application;
using ShopsManagement.Application.Contracts.MarketCategories;
using ShopsManagement.Domain.MarketCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application
{
    public class MarketCategoryApplication : IMarketCategoryApplication
    {
        private readonly IMarketCategoryRepository _marketCategoryRepository;

        public MarketCategoryApplication(IMarketCategoryRepository marketCategoryRepository)
        {
            _marketCategoryRepository = marketCategoryRepository;
        }

        public OperationResult CreateMarketCategory(CreateMarketCategory command)
        {
            var opration = new OperationResult();
            if (_marketCategoryRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var Category = new MarketCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

            _marketCategoryRepository.Create(Category);
            _marketCategoryRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult DeleteMarketCategory(long id)
        {
            var opration = new OperationResult();
          var category = _marketCategoryRepository.Get(id);
            if (category == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            category.DeleteMarketCategory();

            _marketCategoryRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult EditMarketCategory(EditMarketCategory command)
        {
            var opration = new OperationResult();
            var MarketCategory = _marketCategoryRepository.Get(command.Id);
            if(MarketCategory == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            if (_marketCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            MarketCategory.EditMarketCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, slug);
            _marketCategoryRepository.SaveChanges();
            return opration.Successful();
        }

        public EditMarketCategory GetDetails(long id)
        {
            return _marketCategoryRepository.GetDetails(id);
        }

        public List<MarketCategoryViewModel> GetMarketCategories()
        {
           return _marketCategoryRepository.GetMarketCategories();
        }

        public OperationResult RestoreMarketCategory(long id)
        {
            var opration = new OperationResult();
            var category = _marketCategoryRepository.Get(id);
            if (category == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            category.RestoreMarketCategory();

            _marketCategoryRepository.SaveChanges();
            return opration.Successful();
        }

        public List<MarketCategoryViewModel> Search(MarketCategorySearchModel searchModel)
        {
           return _marketCategoryRepository.Search(searchModel);
        }
    }
}
