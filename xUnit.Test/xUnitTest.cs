using System;
using Xunit;
using Model;
using Repository;

namespace xUnit.Test
{
    public class xUnitTest
    {

        string Name = "";
        ContextDB db = new ContextDB();

        string role = "";
        //[Fact]
        //public void AdminNameExist()
        //    {

        //        UserRepos usr = new UserRepos(db);
        //        var users = usr.GetALL();
        //        foreach (var item in users)
        //        {
        //            if (item.User_name == "admin")
        //            {
        //                Name = "admin";
        //                //UsrId = item.User_id;
        //            }
        //        }

        //        Assert.True(Name == "admin");

        //    }
        //[Fact]
        //public void AdminRoleExist()
        //{

        //    RoleRepos rol = new RoleRepos(db);

        //    var roles = rol.GetALL();

        //    foreach (var x in roles)
        //    {
        //        if (x.Role_name == "admin")
        //        {
        //            //RoleId = x.Role_id;
        //            role = "admin";
        //        }
        //    }
        //    Assert.True(role == "admin"); 
        //}
        [Fact]
        public void adminIsAdmin()
        {
            ///////

            UserRepos usr = new UserRepos(db);
            var users = usr.GetALL();
            foreach (var item in users)
            {
                if (item.User_name == "admin")
                {
                    Name = "admin";
                    //UsrId = item.User_id;
                }
            }
            /////////////////
            RoleRepos rol = new RoleRepos(db);

            var roles = rol.GetALL();

            foreach (var x in roles)
            {
                if (x.Role_name == "admin")
                {
                    //RoleId = x.Role_id;
                    role = "admin";
                }
            }
            /////////////////
            Assert.True(Name == role);
        }
        [Fact]
        public void SuccededLogin()
        {
            UserRepos ur = new UserRepos(db);
            //User u = new User();
            string uName = "Basma";
            int password = 123;
            User u = new User();
            u.User_name = uName;
            u.Password = password;
            bool login = ur.SuccedLogin(u);
            //bool x = true;
            Assert.True(login);

        }
        [Fact]
        public void FailedLogin()
        {
            UserRepos ur = new UserRepos(db);
            string uName = "Basma";
            //invaid password 
            int password = 12345;
            User u = new User();
            u.User_name = uName;
            u.Password = password;
            bool login = ur.SuccedLogin(u);
           
            Assert.False(login);


        }


    }
}
    



