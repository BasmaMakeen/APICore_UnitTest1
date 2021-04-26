using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepos : BaseRepos<User>
    {
        public ContextDB _db { get; set; }


        public UserRepos(ContextDB db) {

                _db = db;
            }

            public User Add(User data)
            {
                _db.Add(data);
                _db.SaveChanges();
                return data;
            }

            public bool Delete(int id)
            {
                _db.Remove(_db.users.FirstOrDefault(d => d.User_id == id));
                return true;
            }

            public User Edit(User data)
            {
                User oldstd = _db.users.FirstOrDefault(d => d.User_id == data.User_id);
                oldstd.User_name = data.User_name;
                oldstd.Email = data.Email;
                return oldstd;

            }

            public List<User> GetALL()
            {
                return _db.users.Include(d => d.user_Roles).ToList();
            }

            public User Getbyid(int id)
            {
                throw new NotImplementedException();
            }

            public bool SuccedLogin(User urs)
            {
                User ur = new User();
                if (urs != null)
                {
                    ur = GetALL().FirstOrDefault(d => d.User_name == urs.User_name && d.Password == urs.Password);
                }
                if (ur != null) return true;
                else return false;



            }
        }
    }


  


