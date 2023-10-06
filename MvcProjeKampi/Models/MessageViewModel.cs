using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class MessageViewModel
    {
        public List<Message> MessageList { get; set; }
        public int MessageCount { get; set; }
    }
}