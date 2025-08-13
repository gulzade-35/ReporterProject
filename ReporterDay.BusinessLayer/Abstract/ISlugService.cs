﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Abstract
{
    public interface ISlugService
    {
        string GenerateSlug(string phrase);
    }
}
