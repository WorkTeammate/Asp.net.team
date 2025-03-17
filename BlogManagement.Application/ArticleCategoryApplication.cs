using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
           var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var ArticleCategory = new ArticleCategory(command.Name, command.ShortDescription, command.Picture, command.PictureAlt
                , command.PictureTitle, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress, command.ShowOrder);

            _articleCategoryRepository.Create(ArticleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Successful();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var category = _articleCategoryRepository.Get(id);
            if (category == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            category.Delete();
            _articleCategoryRepository.SaveChanges();
            return operation.Successful();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            articleCategory.Edit(command.Name, command.ShortDescription, command.Picture, command.PictureAlt
                , command.PictureTitle, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress, command.ShowOrder);

            _articleCategoryRepository.SaveChanges();
            return operation.Successful();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
          return _articleCategoryRepository.GetArticleCategories();
        }

        public EditArticleCategory GetDetails(long id)
        {
          return _articleCategoryRepository.GetDetails(id);
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var category = _articleCategoryRepository.Get(id);
            if (category == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            category.Restore();
            _articleCategoryRepository.SaveChanges();
            return operation.Successful();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
