using Microsoft.EntityFrameworkCore;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.DataAccessLayer.Context;
using ReporterDay.DataAccessLayer.Repositories;
using ReporterDay.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly ArticleContext _context;
        public EfArticleDal(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public List<Article> GetArticleByAuthor(string id)
        {
            var values = _context.Articles.Where(x=>x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetArticlesByCategoryId1()
        {
            var values = _context.Articles.Where(x => x.CategoryId == 1).ToList();
            return values;
        }

        public List<Article> GetArticlesWithAppUser()
        {
            var values = _context.Articles.Include(x => x.AppUser).ToList();
            return values;
        }

        public Article GetArticlesWithAuthorAndCategoriesById(int id)
        {
            var values = _context.Articles.Include(x => x.AppUser).Include(y => y.Category).Where(z => z.ArticleId == id).FirstOrDefault();
            return values;
        }

        public List<Article> GetArticlesWithCategories()
        {
            return _context.Articles.Include(x => x.Category).ToList();
        }

        public List<Article> GetArticlesWithCategoriesAndAppUsers()
        {
            return _context.Articles.Include(x => x.Category).Include(x => x.AppUser).ToList();
        }

        public Article GetBySLug(string slug)
        {
            return _context.Articles.Include(x => x.Category).Include(x => x.AppUser).FirstOrDefault(x => x.Slug == slug);
        }
    }
}
