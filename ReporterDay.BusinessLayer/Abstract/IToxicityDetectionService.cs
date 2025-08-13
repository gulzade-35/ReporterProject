using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Abstract
{
    public interface IToxicityDetectionService
    {
        Task<ToxicityDetectionResult> DetectToxicityAsync(string commnetText);
    }

    public class ToxicityDetectionResult
    {
        public bool IsToxic { get; set; }
        public double Score { get; set; }
        public string DetectedLabel { get; set; }
    }
}
