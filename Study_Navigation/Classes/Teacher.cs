using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Teacher
    {
        [Key]
        public int id_teacher { get; set; }
        public string FCs { get; set; }
        public string E_Mail { get; set; }
        public virtual ICollection<Disciplines> Disciplines { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
