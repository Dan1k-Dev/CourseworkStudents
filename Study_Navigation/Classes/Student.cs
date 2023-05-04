using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation
{
    public class Student
    {
        [Key]
        public int id_student { get; set; }
        public string FCs { get; set; }
        public int numb_of_gradebook { get; set; }
        public string date_of_born { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public int group { get; set; }
        public string fluorography { get; set; }
        public virtual ICollection<Attendance_Student> Attendance_Students { get; set; }
        public virtual ICollection<Student_Progress> Student_Progresses { get; set; }
        public virtual Group Groups { get; set; }
    }
}
