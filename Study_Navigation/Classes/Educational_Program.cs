using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Educational_Program
    {
        [Key]
        public int id_program { get; set; }
        public string title_program { get; set; }
        public string head_department { get; set; }
        public int form_education { get; set; }
        public int specialization { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual Form_Of_Education Form_Of_ { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}