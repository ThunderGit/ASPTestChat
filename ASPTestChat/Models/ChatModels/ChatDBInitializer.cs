using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASPTestChat.Models
{
    public class ChatDBInitializer : CreateDatabaseIfNotExists<ChatContext>
    {
        protected override void Seed(ChatContext db)
        {
            
            User Admin=new User { 
                Name = "Admin", 
                _Email = "ASPTestChatAdmin@gmail.com", 
                Password = Convert.ToString("admin123".GetHashCode())
            };

            Message adminMessage=new Message{
                PostDate=DateTime.Now,
                Text="The chat has been started.",
                user=Admin,
                UserID=Admin.ID
            };

            Admin.UserMessages.Add(adminMessage);

            db.Users.Add(Admin);
            db.Messages.Add(adminMessage);
            db.SaveChanges();
        }
    }
}