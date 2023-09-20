using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new  EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        //En fazla başlığa sahip kategori adı
        public ActionResult CategoryWithMostHeadings()
        {
            var categories = cm.GetList(); // Tüm kategorileri al

            int maxHeadingCount = 0; // Başlangıçta en fazla başlık sayısını sıfır olarak ayarlayın
            string categoryNameWithMostHeadings = ""; // Başlangıçta en fazla başlığa sahip kategori adını boş olarak ayarlayın

            foreach (var category in categories)
            {
                int headingCount = hm.GetByCategoryID(category.CategoryID).Count; // Her kategorinin başlık sayısını al

                if (headingCount > maxHeadingCount)
                {
                    maxHeadingCount = headingCount; // Eğer bu kategori daha fazla başlığa sahipse güncelle
                    categoryNameWithMostHeadings = category.CategoryName;
                }
            }

            ViewBag.CategoryWithMostHeadings = categoryNameWithMostHeadings; // Sonucu ViewBag ile görünüme aktar

            return View();
        }

        //Kategori Adı
        public int GetCategoryIdByName(string categoryName)
        {
            var category = cm.GetList().FirstOrDefault(c => c.CategoryName == categoryName);
            return category != null ? category.CategoryID : -1; // Eğer kategori bulunamazsa -1 döndürülebilir.
        }

        //Status Control
        public ActionResult GetCategoryStatusCounts()
        {
            var categoryStatusCounts = cm.GetCategoryStatusCounts();

            int trueCount = categoryStatusCounts.ContainsKey(true) ? categoryStatusCounts[true] : 0;
            int falseCount = categoryStatusCounts.ContainsKey(false) ? categoryStatusCounts[false] : 0;

            ViewBag.TrueCategoryCount = trueCount;
            ViewBag.FalseCategoryCount = falseCount;

            return View();
        }

        public ActionResult Index()
        {
            //Toplam Kategori Sayısı
            var categoryList = cm.GetList();
            int categoryCount = categoryList.Count;

            ViewBag.CategoryCount = categoryCount;


            // Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            int categoryId = GetCategoryIdByName("Yazılım"); // "Yazılım" kategorisinin ID'sini al

            var yazilimBasliklar = hm.GetByCategoryID(categoryId); // "Yazılım" kategorisinin başlıklarını al
            int yazilimBaslikCount = yazilimBasliklar.Count();

            ViewBag.YazilimBaslikCount = yazilimBaslikCount;


            //Yazar adında 'a' harfi geçen yazar sayısı
            List<Writer> yazarlarAHarfiGecen = wm.GetWritersWithLetterA();
            int yazarSayisiAHarfiGecen = yazarlarAHarfiGecen.Count;

            ViewBag.YazarSayisiAHarfiGecen = yazarSayisiAHarfiGecen;


            //En fazla başlığa sahip kategori adı
            CategoryWithMostHeadings();


            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            GetCategoryStatusCounts();


            return View();
          
        }

    }
}