using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Study_Navigation.Classes
{
    public class Journal_Interactions
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string status { get; set; }
    }
}
