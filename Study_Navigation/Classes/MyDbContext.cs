using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Study_Navigation
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Access_Rights> rights { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student_Progress> student_s { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Progress_Group> progress_Groups { get; set; }
        public DbSet<Personal_Document> personal_s { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Form_Of_Education> form_Ofs { get; set; }
        public DbSet<Educational_Program> educational_s { get; set; }
        public DbSet<Disciplines> _disciplines { get; set; }
        public DbSet<Attendance_Student> attendance_s { get; set; }
        public DbSet<Attendance_Group> attendances { get; set; }
    } 
}
