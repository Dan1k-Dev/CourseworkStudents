using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Group
    {
        [Key]
        public int id_group { get; set; }
        public string Title_group { get; set; }
        public string Year_of_recruitment { get; set; }
        public string Elder_of_group { get; set; }
        public int Director_teacher { get; set; }
        public int Educational_program { get; set; }
        public virtual Teacher Teacher { get; set; }
       // public virtual Educational_Program Educational { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
