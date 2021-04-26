using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public int Password { get; set; }


        public List<User_Role> user_Roles { get; set; }
    }
}
