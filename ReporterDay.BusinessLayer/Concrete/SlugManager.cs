using ReporterDay.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Concrete
{
    public class SlugManager : ISlugService
    {

        public string GenerateSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return Guid.NewGuid().ToString();

            string str = phrase.ToLowerInvariant();

            // Türkçe karakterleri İngilizce karşılığına çevir (isteğe bağlı)
            str = str.Replace("ı", "i").Replace("ö", "o").Replace("ü", "u")
                     .Replace("ş", "s").Replace("ğ", "g").Replace("ç", "c");

            // Özel karakterleri temizle
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // Boşlukları tire yap
            str = Regex.Replace(str, @"\s+", " ").Trim();
            //str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }
    }
}
