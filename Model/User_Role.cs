using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class User_Role
    {
        [Key]
        public int UR_ID { get; set; }
        [ForeignKey("role")]
        public int Role_id { get; set; }
        [ForeignKey("user")]
        public int User_id { get; set; }
        public User user { get; set; }
        public Role role { get; set; }
    }
}
