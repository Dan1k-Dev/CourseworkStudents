using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Student_Progress
    {
        [Key]
        public int id_progress { get; set; }
        public int student { get; set; }
        public int descipline { get; set; }
        public int estimation { get; set; }
        public virtual Student Student { get; set; }
        public virtual Disciplines Discipline { get; set; }
    }
}