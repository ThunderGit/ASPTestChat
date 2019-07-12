using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTestChat.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public string _Email { get; set; }
        public string Password { get; set; }
        public ICollection<Message> UserMessages { get; set; }

        public User()
        {
            UserMessages = new List<Message>();
        }
    }
}