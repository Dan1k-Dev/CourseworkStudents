using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Access_Rights
    {
        [Key]
        public int id_right { get; set; }
        public string Access_right { get; set; }
        public virtual User user { get; set; }
    }
}
