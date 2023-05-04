using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Study_Navigation.Classes;

namespace Study_Navigation
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("ConnectString")
        {

        }
        public DbSet<Access_Rights> Access_Rights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance_Student> Attendances { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<Educational_Program> Educational_s { get; set; }
        public DbSet<Form_Of_Education> Form_Of_s { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Progress> Student_s { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Journal_Enter_Exit> journal_firsts { get; set; }
        public DbSet<Journal_Interactions> journal_s { get; set; }
    }
}
