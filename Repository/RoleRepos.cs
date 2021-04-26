using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class RoleRepos : BaseRepos<Role>
    {
        public ContextDB _db { get; set; }


        public RoleRepos(ContextDB db) { 

       
            _db = db;
        }

        public Role Add(Role data)
        {
            _db.Add(data);
            _db.SaveChanges();
            return data;
        }

        public bool Delete(int id)
        {
            _db.Remove(_db.Roles.FirstOrDefault(d => d.Role_id == id));
            return true;
        }

        public Role Edit(Role data)
        {
            Role oldstd = _db.Roles.FirstOrDefault(d => d.Role_id == data.Role_id);
            oldstd.Role_name = data.Role_name;
            
            return oldstd;

        }

        public List<Role> GetALL()
        {
            return _db.Roles.Include(d => d.user_Roles).ToList();
        }

        public Role Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
