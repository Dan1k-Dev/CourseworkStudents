using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Disciplines
    {
        [Key]
        public int id_discipline { get; set; }
        public string title_discipline { get; set; }
        public int teacher { get; set; }
        public int quantity_of_hours { get; set; }
        public virtual Teacher Teachers { get; set; }
    }
}
