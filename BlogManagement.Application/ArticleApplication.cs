using _01_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var article = new Article(command.Title, command.ShortDescription
                , command.Description, command.Picture, command.PictureAlt, command.PictureTitle
                , slug, publishDate, command.MetaDescription, command.CanonicalAddress, command.CategoryId,command.KeyWords);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();

            return operation.Successful();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var Article = _articleRepository.Get(id);
            if(Article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Article.Delete();
            _articleRepository.SaveChanges();

            return operation.Successful();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(command.Id);
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            article.Edit(command.Title, command.ShortDescription, command.Description
                , command.Picture, command.PictureAlt, command.PictureTitle
                , slug, publishDate, command.MetaDescription, command.CanonicalAddress, command.CategoryId,command.KeyWords);

            _articleRepository.SaveChanges();

            return operation.Successful();


        }

        public List<ArticleViewModel> GetArticles()
        {
           return _articleRepository.GetArticles();
        }

        public EditArticle GetDetails(long id)
        {
           return _articleRepository.GetDetails(id);
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var Article = _articleRepository.Get(id);
            if (Article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Article.Restore();
            _articleRepository.SaveChanges();

            return operation.Successful();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
