using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ContextDB:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { User_id = 1, User_name = "Basma" ,Password=123},

                 new User { User_id = 2, User_name = "Eman", Password = 456 },
                 new User { User_id = 3, User_name = "admin", Password = 789 }

                );
            modelBuilder.Entity<Role>().HasData(
                new Role { Role_id = 1, Role_name = "admin" },
                 new Role { Role_id = 2, Role_name = "user" }
                );
            modelBuilder.Entity<User_Role>().HasData(

               new User_Role{ UR_ID = 1, User_id = 2, Role_id = 1 },
               new User_Role{ UR_ID = 2, User_id = 1, Role_id = 2 },
               new User_Role{ UR_ID = 3, User_id = 3, Role_id = 1 }

            

               );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {


                optionsBuilder.UseSqlServer("server=.;database=UserRoleDb;trusted_connection=true");
            
            }
        }
        public DbSet<User> users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
    }
}
