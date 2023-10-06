using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ContactViewModel
    {
        public List<Contact> ContactList { get; set; }
        public int ContactCount { get; set; }
    }
}