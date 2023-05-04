using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FCs { get; set; }
        public int Access_rights { get; set; }

        public virtual ICollection<Access_Rights> Access_s { get; set; }

    }    
}
