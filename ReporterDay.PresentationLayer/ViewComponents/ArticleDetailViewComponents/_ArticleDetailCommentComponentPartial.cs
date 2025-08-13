using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using System.Threading.Tasks;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailCommentComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IToxicityDetectionService _toxicityDetectionService;

        public _ArticleDetailCommentComponentPartial(ICommentService commentService, IToxicityDetectionService toxicityDetectionService)
        {
            _commentService = commentService;
            _toxicityDetectionService = toxicityDetectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = _commentService.TGetCommentsByArticleId(id);
            foreach (var value in values)
            {
                var toxicity = await _toxicityDetectionService.DetectToxicityAsync(value.CommentDetail);
                value.IsToxic = toxicity.IsToxic;
                value.ToxicityScore = (float)toxicity.Score;
            }   

            return View(values);
        }
    }
}
