using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IHeadingDal _headingDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public List<Heading> GetByCategoryID(int id)
        {
            return _headingDal.List(x => x.CategoryID == id);
        }

        public Dictionary<bool, int> GetCategoryStatusCounts()
        {
            var categories = _categoryDal.List();
            var counts = categories.GroupBy(c => c.CategoryStatus).ToDictionary(g => g.Key, g => g.Count());
            return counts;
        }

       

    }
}
