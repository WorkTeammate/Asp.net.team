using _0_Framework.Application;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Application.Contracts.Shops;
using ShopsManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application
{
    public class MarketApplication : IMarketApplication
    {
        private readonly IMarketsRepository _marketsRepository;

        public MarketApplication(IMarketsRepository marketsRepository)
        {
            _marketsRepository = marketsRepository;
        }

        public OperationResult CreateMarket(CreateMarkets command)
        {
           var opration = new OperationResult();
            if (_marketsRepository.Exists(x => x.EnglishName == command.EnglishName && x.PersianName == command.PersianName))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _marketsRepository.GetSlugById(command.CategoryId);

            var market = new Markets(command.PersianName,command.EnglishName,command.Description,command.ShortDescription,command.Picture,
                command.PictureAlt,command.PictureTitle, slug,command.Latitude,command.Longitude, command.CategoryId 
                , command.KeyWords,command.MetaDescription);
            _marketsRepository.Create(market);
            _marketsRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult EditMarket(EditMarkets command)
        {
            var opration = new OperationResult();
            var market = _marketsRepository.Get(command.Id);
            if (market == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            if (_marketsRepository.Exists(x => x.EnglishName == command.EnglishName && x.PersianName == command.PersianName
             && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);


            var slug = command.Slug.Slugify();

            market.Edit(command.PersianName, command.EnglishName, command.Description, command.ShortDescription, command.Picture,
                command.PictureAlt, command.PictureTitle, slug, command.Latitude,command.Longitude, command.CategoryId 
                , command.KeyWords, command.MetaDescription);

            _marketsRepository.SaveChanges();
            return opration.Successful();
        }

        public EditMarkets GetDetails(long id)
        {
           return _marketsRepository.GetDetails(id);
        }

        public List<MarketViewModel> GetMarkets()
        {
            return _marketsRepository.GetMarkets();
        }

        public OperationResult RemovePage(long id)
        {
            var opration = new OperationResult();

            var market = _marketsRepository.Get(id);
            if (market == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            market.RemovePage();
            _marketsRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult RestorePage(long id)
        {
            var opration = new OperationResult();

            var market = _marketsRepository.Get(id);
            if (market == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            market.RestorePage();
            _marketsRepository.SaveChanges();
            return opration.Successful();
        }

        public List<MarketViewModel> Search(MarketSearchModel searchModel)
        {
            return _marketsRepository.Search(searchModel);
        }
    }
}
