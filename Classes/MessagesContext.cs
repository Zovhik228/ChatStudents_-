using ChatStudents_Пешков.Classes.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatStudents_Пешков.Classes
{
    public class MessagesContext : DbContext
    {
        public DbSet<Messages> Messages { get; set; }
        public MessagesContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Config.config);
    }
}
