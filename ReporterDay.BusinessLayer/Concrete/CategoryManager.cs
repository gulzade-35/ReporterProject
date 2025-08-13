﻿using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public int TGetCategoryCount()
        {
            return _categoryDal.GetCategoryCount();
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TInsert(Category entitiy)
        {
            if (entitiy.CategoryName.Length >= 3 && entitiy.CategoryName.Length <= 20)
            {
                _categoryDal.Insert(entitiy);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Category entity)
        {
            if (entity.CategoryName.Length >= 3 && entity.CategoryName.Length <= 20 && entity.CategoryName.Contains('a'))
            {
                _categoryDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }
    }
}
