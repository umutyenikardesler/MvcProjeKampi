using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            var data = BlogList();
            return Json(data, JsonRequestBehavior.AllowGet);
            //return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();

            var categoryvalues = cm.GetList();

            foreach (var item in categoryvalues)
            {
                int headingCount = hm.GetByCategoryID(item.CategoryID).Count;

                ct.Add(new CategoryClass()
                {
                    CategoryName = item.CategoryName,
                    CategoryCount = headingCount
                });

            }
            return ct;

        }

    }
}