using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        List<ArticleCategoryViewModel> GetArticleCategories();
        OperationResult Delete(long id);
        OperationResult Restore(long id);


    }
}
