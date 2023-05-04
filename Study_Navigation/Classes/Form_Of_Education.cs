using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Form_Of_Education
    {
        [Key]
        public int id_form { get; set; }
        public string title_form { get; set; }
        public virtual ICollection<Educational_Program> Educational_s { get; set; }
    }
}
