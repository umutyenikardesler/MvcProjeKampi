using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
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

        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            //var contactCount = contactvalues.Count;

            //var viewModel = new ContactViewModel
            //{
            //    ContactList = contactvalues,
            //    ContactCount = contactCount
            //};

            return View(contactvalues);
        }

        //public PartialViewResult PVMessageListMenu(ContactViewModel model)
        //{
        //    return PartialView(model);
        //}

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);

            contactvalues.IsRead = true;
            cm.ContactUpdate(contactvalues);

            return View(contactvalues);
        }

        public PartialViewResult PVMessageListMenu()
        {
            var contactvalues = cm.GetList().Where(x=>x.IsRead==false).ToList();

            ViewBag.CountOfContact = contactvalues.Count().ToString();
            return PartialView("PVMessageListMenu", ViewBag.CountOfContact);
        }

    }
}