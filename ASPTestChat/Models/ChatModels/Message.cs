using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTestChat.Models
{
    public class Message
    {
        public int ID { get; set; }
        public DateTime PostDate { get; set; }
        public string Text { get; set; }
        public User user { get; set; }
        public int UserID  { get; set; }
    }
}