using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASPTestChat.Models
{
    public class ChatContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Настройка Foreign Key (Связь "Один ко многим")
            modelBuilder.Entity<Message>()
                .HasRequired<User>(m => m.user)
                .WithMany(u => u.UserMessages)
                .HasForeignKey<int>(m => m.UserID);
        }
    
    }
}