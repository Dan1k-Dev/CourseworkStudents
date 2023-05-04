using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Attendance_Group
    {
        [Key]
        public int id_attendance { get; set; }
        public int _group { get; set; }
        public string date { get; set; }
        public int quantity_of_hours_GR { get; set; }
        public int quantity_of_hours_nGR { get; set; }
        public int General_quantity_of_hours { get; set; }
        public virtual Group Group { get; set; }
    }
}
