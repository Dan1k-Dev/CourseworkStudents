using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Personal_Document
    {
        [Key]
        public int  id_personal_document { get; set; }
        public string date_of_born { get; set; }
        public string residence_address { get; set; }
        public string actual_address { get; set; }
        public string telephone { get; set; }
        public string education { get; set; }
        public int _group { get; set; }
        public string parent_telephone { get; set; }
        public string Fs_parent { get; set; }
        public bool fluorography { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual Group Group { get; set; }
    }
}