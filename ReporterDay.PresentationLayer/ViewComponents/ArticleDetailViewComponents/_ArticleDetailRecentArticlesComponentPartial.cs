using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailRecentArticlesComponentPartial : ViewComponent
    {
        public readonly IArticleService _articleService;

        public _ArticleDetailRecentArticlesComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var recentArticles = _articleService.TGetListAll()
                                                .OrderByDescending(x => x.CreateDate)
                                                .Take(5)
                                                .ToList();
            return View(recentArticles);
        }
    }
}
