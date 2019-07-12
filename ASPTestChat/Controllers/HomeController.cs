using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTestChat.Models;
using System.Web.Security;
using System.Web.Mail;

namespace ASPTestChat.Controllers
{
    public class HomeController : Controller
    {
        static ChatContext chat = new ChatContext();
        static List<User> users = new List<User>();
        static List<Message> messages = new List<Message>();
       
        public ActionResult Index()
        {
            users = chat.Users.ToList<User>();
            messages = chat.Messages.ToList<Message>();
            ViewBag.Users = users;
            ViewBag.Messages = messages;
            return View();
        }
        public ActionResult Chat(string chatUser, string chatMessage)
        {
            if(messages.Count>100)//Если сообщений больше 100, то оставляем последние 10
            {
                messages.RemoveRange(0, 90);
            }

            // Устанавливаем залогиненного пользователя 
            User currentUser = chat.Users.FirstOrDefault(u => u.Name == chatUser);

            // Добавляем в список сообщений новое сообщение пользователя
            Message NewMessage = new Message()
            {
                PostDate = DateTime.Now,
                Text = chatMessage,
                user = currentUser,
                UserID = currentUser.ID
            };
            chat.Messages.Add(NewMessage);
            chat.SaveChanges();

            messages.Add(NewMessage);
            chat.Users.FirstOrDefault(u => u.Name == chatUser).UserMessages.Add(NewMessage);
            chat.SaveChanges();

            users = chat.Users.ToList<User>();
            messages = chat.Messages.ToList<Message>();

            ViewBag.Users = users;
            ViewBag.Messages = messages;

            return View();
        }

       
    }
}