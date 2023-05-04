using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Specialization
    {
        [Key]
        public int id_specializtion { get; set; }
        public string title_specialization { get; set; }
    }
}