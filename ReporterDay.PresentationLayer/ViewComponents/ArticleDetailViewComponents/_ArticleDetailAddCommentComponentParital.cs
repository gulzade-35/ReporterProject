using Microsoft.AspNetCore.Mvc;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailAddCommentComponentParital: ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            ViewBag.ArticleId = articleId; // ArticleId'yi View'e gönderiyoruz
            return View();
        }
    }
}
