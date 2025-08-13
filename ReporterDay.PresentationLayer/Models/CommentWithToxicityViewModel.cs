namespace ReporterDay.PresentationLayer.Models
{
    public class CommentWithToxicityViewModel
    {
        public ReporterDay.EntityLayer.Entities.Comment Comment { get; set; }
        public bool IsToxic { get; set; }
        public double ToxicityScore { get; set; }
    }
}
