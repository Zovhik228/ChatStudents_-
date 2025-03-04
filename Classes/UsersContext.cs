using ChatStudents_Пешков.Classes.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatStudents_Пешков.Classes
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Config.config);
    }
}