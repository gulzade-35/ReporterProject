using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly ISlugService _slugService;

        public ArticleManager(IArticleDal articleDal, ISlugService slugService)
        {
            _articleDal = articleDal;
            _slugService = slugService;
        }

        public List<Article> TGetArticlesByCategoryId1()
        {
            return _articleDal.GetArticlesByCategoryId1();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetListAll()
        {
            return _articleDal.GetListAll();
        }

        public void TInsert(Article entity)
        {
            if (entity.Title != null && entity.Title.Length > 10 && entity.CategoryId != 0 && entity.Content.Length <= 1000)
            {
                if (string.IsNullOrEmpty(entity.Slug))
                {
                    entity.Slug = _slugService.GenerateSlug(entity.Title);
                }
               
                _articleDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public List<Article> TGetArticlesWithAppUser()
        {
            return _articleDal.GetArticlesWithAppUser();
        }

        public List<Article> TGetArticlesWithCategories()
        {
            return _articleDal.GetArticlesWithCategories();
        }

        public List<Article> TGetArticlesWithCategoriesAndAppUsers()
        {
            return _articleDal.GetArticlesWithCategoriesAndAppUsers();
        }

        public Article TGetArticlesWithAuthorAndCategoriesById(int id)
        {
            return _articleDal.GetArticlesWithAuthorAndCategoriesById(id);
        }

        public List<Article> TGetArticleByAuthor(string id)
        {
            return _articleDal.GetArticleByAuthor(id);
        }

        public Article TGetBySlug(string slug)
        {
            return _articleDal.GetBySLug(slug);
        }
    }
}
