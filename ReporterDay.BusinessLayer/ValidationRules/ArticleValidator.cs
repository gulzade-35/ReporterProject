﻿using FluentValidation;
using ReporterDay.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.ValidationRules
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Makale başlığı boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Makale içeriği boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Başlık en az 10 karakter olmalıdır");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 kararkter olmalıdır");
            RuleFor(x => x.CategoryId).LessThan(0).WithMessage("Kategori Id 0'dan küçük olamaz.");
        }
    }
}
