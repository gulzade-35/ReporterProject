using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.DataAccessLayer.Context;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ArticleContext _context;

        public ArticleController(IArticleService articleService, ArticleContext context)
        {
            _articleService = articleService;
            _context = context;
        }

        [Route("Article/ArticleDetail/{slug}")]
        public IActionResult ArticleDetail(string slug)
        {
            var article = _context.Articles
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .FirstOrDefault( x => x.Slug == slug);
            if (article == null)
            {
                return NotFound();
            }

            ViewBag.id = article.ArticleId;
            return View();
        }
    }
}
