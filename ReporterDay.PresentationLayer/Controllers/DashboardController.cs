using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.DataAccessLayer.Context;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.PresentationLayer.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ArticleContext _context;

        public DashboardController(UserManager<AppUser> userManager, ArticleContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = currentUser.Id;

            ViewBag.FullName = currentUser.Name + " " + currentUser.Surname;
            ViewBag.Image = currentUser.ImageUrl;

            var articles = _context.Articles
                .Where(x => x.AppUserId == userId)
                .Include(x => x.Category)
                .Include(x => x.Comments);

            //toplam makale sayısı
            ViewBag.TotalArticles = await articles.CountAsync();

            //toplam yorum sayısı
            ViewBag.TotalComments = await articles.SumAsync(a => a.Comments.Count);

            var latestArticle = await articles
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefaultAsync();

            if (latestArticle != null)
            {
                ViewBag.LatestArticleTitle = latestArticle.Title;
                ViewBag.LatestArticleDate = latestArticle.CreateDate.ToString("dd MMM yyyy");
                ViewBag.LatestArticleCategory = latestArticle.Category.CategoryName;
                ViewBag.LatestArticleCommentCount = latestArticle.Comments.Count;
            }

           //grafik için

            var data = _context.Articles
           .Include(a => a.Category)
           .GroupBy(a => a.Category.CategoryName)
           .Select(g => new
           {
               Category = g.Key,
               Count = g.Count()
           })
           .ToList();

            ViewBag.Labels = data.Select(x => x.Category).ToList();
            ViewBag.Values = data.Select(x => x.Count).ToList();

            return View();
        }

    }
}
