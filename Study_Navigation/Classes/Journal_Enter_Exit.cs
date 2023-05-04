using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Study_Navigation.Classes
{
    public class Journal_Enter_Exit
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string status { get; set; }
    }
}
