using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfCantactDal());
        ContactValidator cv = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();

            int contactCount = contactvalues.Count;
            ViewBag.ContactCount = contactCount;

            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult PVMessageListMenu()
        {
            return PartialView();
        }

    }
}